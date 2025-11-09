using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookiFind.Application.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CookidooId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeNutritionInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CaloriesInKcal = table.Column<double>(type: "double precision", nullable: false),
                    ProteinInGrams = table.Column<double>(type: "double precision", nullable: false),
                    CarbohydratesInGrams = table.Column<double>(type: "double precision", nullable: false),
                    FatInGrams = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeNutritionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CookidooId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    NutritionInfoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "RecipeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeNutritionInfo_NutritionInfoId",
                        column: x => x.NutritionInfoId,
                        principalTable: "RecipeNutritionInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "CookidooId", "Name" },
                values: new object[,]
                {
                    { new Guid("03d7257b-cee0-4256-8e43-aac489787fc8"), "VrkNavCategory-RPF-002", "Soups" },
                    { new Guid("12942154-0672-4e48-9789-ed5daf656a0f"), "VrkNavCategory-RPF-006", "Main dishes – Vegetarian" },
                    { new Guid("21b494af-71fd-4da8-a42c-921e94453b95"), "VrkNavCategory-RPF-014", "Breads and Rolls" },
                    { new Guid("2c6e2238-4fb0-4eb7-913f-7571351e1a7f"), "VrkNavigationCategory-rpf-000001303095", "Menus and More" },
                    { new Guid("39de8ea0-b0d8-4c66-8516-e1c55ee6a6bb"), "VrkNavCategory-RPF-009", "Sauces, Dips and Spreads – Sweet" },
                    { new Guid("4e6c95d6-849e-4e0e-8a37-c93af32ed540"), "VrkNavCategory-RPF-012", "Baking – Savory" },
                    { new Guid("5c818977-76b8-4014-a513-26a64d207d06"), "VrkNavCategory-RPF-008", "Side Dishes" },
                    { new Guid("66b44fe0-2a7a-448c-a75f-0882754030d9"), "VrkNavCategory-RPF-011", "Desserts and Sweets" },
                    { new Guid("73dd6368-5c3f-4840-aa67-7ecb4bb5aaa9"), "VrkNavCategory-RPF-018", "Sauces, Dips and Spreads – Savory" },
                    { new Guid("8a3e3682-a69c-4f58-bcca-94ff48de8b5f"), "VrkNavCategory-RPF-015", "Drinks" },
                    { new Guid("91957ae5-bf50-4d48-9839-d284ea778c26"), "VrkNavCategory-RPF-019", "Breakfast" },
                    { new Guid("af15b6fc-03d1-4c90-bc86-37bb1fdd1ed8"), "VrkNavCategory-RPF-020", "Snacks" },
                    { new Guid("b4761e36-4e96-43ae-802e-53595420a52b"), "VrkNavCategory-RPF-017", "Baby food" },
                    { new Guid("c93a8d27-d348-4eae-a989-067aca6fc869"), "VrkNavCategory-RPF-016", "Basics" },
                    { new Guid("dacbb358-6082-4a10-a210-9a459077f0d5"), "VrkNavCategory-RPF-003", "Pasta & Rice Dishes" },
                    { new Guid("de6b17c6-463a-49e6-9dc1-f0dc42507c6d"), "VrkNavCategory-RPF-005", "Main dishes – Fish" },
                    { new Guid("f7278ad5-3d3c-4912-b42d-92487e1fbbe9"), "VrkNavCategory-RPF-013", "Baking – Sweet" },
                    { new Guid("f8eff110-05ee-4b94-96f3-55d934e4521a"), "VrkNavCategory-RPF-007", "Main dishes – Other" },
                    { new Guid("fb487a86-7f4b-4536-954b-b5616e8dd821"), "VrkNavCategory-RPF-004", "Main dishes – Meat" },
                    { new Guid("fd0758a6-a1ed-4d05-afdc-d6e4189c7f21"), "VrkNavCategory-RPF-001", "Appetizers" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_NutritionInfoId",
                table: "Recipes",
                column: "NutritionInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropTable(
                name: "RecipeNutritionInfo");
        }
    }
}
