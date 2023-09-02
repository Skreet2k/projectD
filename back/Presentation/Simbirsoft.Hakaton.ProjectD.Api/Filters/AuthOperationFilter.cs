using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Simbirsoft.Hakaton.ProjectD.Api.Filters;

public class AuthOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext ctx)
    {
        if (!(ctx.ApiDescription.ActionDescriptor is ControllerActionDescriptor actionDescriptor) ||
            ctx.ApiDescription.CustomAttributes().Any<object>(a => a is AllowAnonymousAttribute) ||
            (!ctx.ApiDescription.CustomAttributes().Any<object>(a => a is AuthorizeAttribute) &&
             actionDescriptor.ControllerTypeInfo.GetCustomAttribute<AuthorizeAttribute>() == null))
            return;
        var array = ctx.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>()
            .Select((Func<AuthorizeAttribute, string>)(a => a.Roles))
            .Where((Func<string, bool>)(r => !string.IsNullOrEmpty(r))).Distinct().ToArray();
        if (!array.Any())
        {
            var declaringType = ctx.MethodInfo.DeclaringType;
            array = (object)declaringType != null
                ? declaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>()
                    .Select((Func<AuthorizeAttribute, string>)(attr => attr.Roles))
                    .Where((Func<string, bool>)(r => !string.IsNullOrEmpty(r))).Distinct().ToArray()
                : null;
        }

        var flag = ((IEnumerable<string>)array).Any();
        if (flag)
        {
            var str = string.Join(',', array);
            var openApiOperation = operation;
            openApiOperation.Description = openApiOperation.Description + "Обязательная роль: " + str;
        }

        IList<OpenApiSecurityRequirement> security = operation.Security;
        var securityRequirement = new OpenApiSecurityRequirement();
        securityRequirement[new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        }] = flag ? array : (IList<string>)Array.Empty<string>();
        security.Add(securityRequirement);
    }
}