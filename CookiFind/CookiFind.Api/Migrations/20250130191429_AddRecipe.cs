using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookiFind.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_RecipeCategories_CategoryId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_RecipeNutritionInfo_NutritionInfoId",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Recipes");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_NutritionInfoId",
                table: "Recipes",
                newName: "IX_Recipes_NutritionInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_CategoryId",
                table: "Recipes",
                newName: "IX_Recipes_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeCategories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "RecipeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeNutritionInfo_NutritionInfoId",
                table: "Recipes",
                column: "NutritionInfoId",
                principalTable: "RecipeNutritionInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeCategories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeNutritionInfo_NutritionInfoId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipe");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_NutritionInfoId",
                table: "Recipe",
                newName: "IX_Recipe_NutritionInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipe",
                newName: "IX_Recipe_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_RecipeCategories_CategoryId",
                table: "Recipe",
                column: "CategoryId",
                principalTable: "RecipeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_RecipeNutritionInfo_NutritionInfoId",
                table: "Recipe",
                column: "NutritionInfoId",
                principalTable: "RecipeNutritionInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
