using CookiFind.Application.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace CookiFind.Application.Database;

public class CookiFindDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeCategory> RecipeCategories { get; set; }

    public CookiFindDbContext(DbContextOptions<CookiFindDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeCategory>()
            .HasData(
                [
                    new RecipeCategory{
                        Id = Guid.Parse("fd0758a6-a1ed-4d05-afdc-d6e4189c7f21"),
                        CookidooId = "VrkNavCategory-RPF-001",
                        Name = "Appetizers"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("03d7257b-cee0-4256-8e43-aac489787fc8"),
                        CookidooId = "VrkNavCategory-RPF-002",
                        Name = "Soups"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("dacbb358-6082-4a10-a210-9a459077f0d5"),
                        CookidooId = "VrkNavCategory-RPF-003",
                        Name = "Pasta & Rice Dishes"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("fb487a86-7f4b-4536-954b-b5616e8dd821"),
                        CookidooId = "VrkNavCategory-RPF-004",
                        Name = "Main dishes – Meat"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("de6b17c6-463a-49e6-9dc1-f0dc42507c6d"),
                        CookidooId = "VrkNavCategory-RPF-005",
                        Name = "Main dishes – Fish"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("12942154-0672-4e48-9789-ed5daf656a0f"),
                        CookidooId = "VrkNavCategory-RPF-006",
                        Name = "Main dishes – Vegetarian"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("f8eff110-05ee-4b94-96f3-55d934e4521a"),
                        CookidooId = "VrkNavCategory-RPF-007",
                        Name = "Main dishes – Other"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("5c818977-76b8-4014-a513-26a64d207d06"),
                        CookidooId = "VrkNavCategory-RPF-008",
                        Name = "Side Dishes"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("39de8ea0-b0d8-4c66-8516-e1c55ee6a6bb"),
                        CookidooId = "VrkNavCategory-RPF-009",
                        Name = "Sauces, Dips and Spreads – Sweet"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("66b44fe0-2a7a-448c-a75f-0882754030d9"),
                        CookidooId = "VrkNavCategory-RPF-011",
                        Name = "Desserts and Sweets"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("4e6c95d6-849e-4e0e-8a37-c93af32ed540"),
                        CookidooId = "VrkNavCategory-RPF-012",
                        Name = "Baking – Savory"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("f7278ad5-3d3c-4912-b42d-92487e1fbbe9"),
                        CookidooId = "VrkNavCategory-RPF-013",
                        Name = "Baking – Sweet"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("21b494af-71fd-4da8-a42c-921e94453b95"),
                        CookidooId = "VrkNavCategory-RPF-014",
                        Name = "Breads and Rolls"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("8a3e3682-a69c-4f58-bcca-94ff48de8b5f"),
                        CookidooId = "VrkNavCategory-RPF-015",
                        Name = "Drinks"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("c93a8d27-d348-4eae-a989-067aca6fc869"),
                        CookidooId = "VrkNavCategory-RPF-016",
                        Name = "Basics"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("b4761e36-4e96-43ae-802e-53595420a52b"),
                        CookidooId = "VrkNavCategory-RPF-017",
                        Name = "Baby food"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("73dd6368-5c3f-4840-aa67-7ecb4bb5aaa9"),
                        CookidooId = "VrkNavCategory-RPF-018",
                        Name = "Sauces, Dips and Spreads – Savory"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("91957ae5-bf50-4d48-9839-d284ea778c26"),
                        CookidooId = "VrkNavCategory-RPF-019",
                        Name = "Breakfast"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("af15b6fc-03d1-4c90-bc86-37bb1fdd1ed8"),
                        CookidooId = "VrkNavCategory-RPF-020",
                        Name = "Snacks"
                    },
                    new RecipeCategory{
                        Id = Guid.Parse("2c6e2238-4fb0-4eb7-913f-7571351e1a7f"),
                        CookidooId = "VrkNavigationCategory-rpf-000001303095",
                        Name = "Menus and More"
                    },
                ]
            );
    }
}
