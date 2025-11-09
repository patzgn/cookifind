using CookiFind.Api.Endpoints;
using CookiFind.Application;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddAuthorization();

builder.Services.AddOpenApi();

builder.Services.AddHttpClient();

builder.Services.AddApplication();
builder.Services.AddDatabase(config["Database:ConnectionString"]!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Servers = Array.Empty<ScalarServer>();
    });
}

app.UseHttpsRedirection();

app.MapApiEndpoints();

app.Run();
