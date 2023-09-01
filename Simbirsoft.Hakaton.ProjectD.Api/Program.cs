using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simbirsoft.Hakaton.ProjectD.Api.Hubs;
using Simbirsoft.Hakaton.ProjectD.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

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
    .WithOrigins()
    .AllowCredentials()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapHub<MyHub>("/hubs/myhub");
});

app.Run();
