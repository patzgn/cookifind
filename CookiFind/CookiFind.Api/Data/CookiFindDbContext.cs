using CookiFind.Api.Models.Domain.Recipes;
using CookiFind.Api.Models.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CookiFind.Api.Data;

public class CookiFindDbContext(DbContextOptions<CookiFindDbContext> options)
    : IdentityDbContext<CookiFindUser>(options)
{
    public DbSet<RecipeCategory> RecipeCategories { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
}
