using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Simbirsoft.Hakaton.ProjectD.Api.Filters;
using Simbirsoft.Hakaton.ProjectD.Api.Models;
using Simbirsoft.Hakaton.ProjectD.Application.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Application.Hubs;
using Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;
using Simbirsoft.Hakaton.ProjectD.Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "This is fine", Version = "v1" });
    c.DescribeAllParametersInCamelCase();

    c.OperationFilter<AuthOperationFilter>();

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
});

builder.Services.AddCors();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddSignalR().AddJsonProtocol(options =>
{
    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
    options.PayloadSerializerOptions.Converters
        .Add(new JsonStringEnumConverter());
});

var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbConfig)).Get<MongoDbConfig>();

builder.Services.AddIdentityCore<User>()
    .AddMongoDbStores<User, Role, Guid>(mongoDbSettings.ConnectionString, mongoDbSettings.Name).AddApiEndpoints();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGroup("api/v1").MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<GameHub>("/hubs/game");

app.Run();