using CookiFind.Api.Data;
using CookiFind.Api.Endpoints.Recipes;
using CookiFind.Api.Extensions;
using CookiFind.Api.Models.Domain.Users;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddCookiFindDbContext();
builder.AddCookiFindRepositories();
builder.AddCookiFindServices();
builder.AddCookidooScraper();

builder.Services.AddHttpClient();

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<CookiFindUser>()
    .AddEntityFrameworkStores<CookiFindDbContext>();

builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CookiFindDbContext>();
    await DataSeeder.SeedAsync(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGroup("api/v1/")
    .MapRecipeEndpoints()
    .MapRecipeCategoriesEndpoints()
    .MapIdentityApi<CookiFindUser>();

app.Run();
