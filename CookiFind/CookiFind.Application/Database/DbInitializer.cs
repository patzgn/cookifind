using Dapper;
using Microsoft.Extensions.Logging;

namespace CookiFind.Application.Database;

public class DbInitializer(IDbConnectionFactory dbConnectionFactory, ILogger<DbInitializer> logger)
{
    public async Task InitializeAsync()
    {
        using var connection = await dbConnectionFactory.CreateConnectionAsync();

        await connection.ExecuteAsync(
            """
            create table if not exists recipe_categories (
            id uuid primary key,
            cookidoo_id text not null,
            name TEXT not null);
            """);

        await connection.ExecuteAsync(
            """
            create table if not exists recipe_nutrition_infos (
            id uuid primary key,
            calories_in_kcal double precision not null,
            proteins_in_grams double precision not null,
            carbohydrates_in_grams double precision not null,
            fats_in_grams double precision not null);
            """);

        await connection.ExecuteAsync(
            """
            create table if not exists recipes (
            id uuid primary key,
            cookidoo_id text not null,
            name text not null,
            category_id uuid references recipe_categories (id),
            nutrition_info_id uuid references recipe_nutrition_infos (id));
            """);

        await connection.ExecuteAsync(
            """
            insert into recipe_categories 
                (id, cookidoo_id, name)
            values 
                ('fd0758a6-a1ed-4d05-afdc-d6e4189c7f21', 'VrkNavCategory-RPF-001', 'Appetizers'),
                ('03d7257b-cee0-4256-8e43-aac489787fc8', 'VrkNavCategory-RPF-002', 'Soups'),
                ('dacbb358-6082-4a10-a210-9a459077f0d5', 'VrkNavCategory-RPF-003', 'Pasta & Rice Dishes'),
                ('fb487a86-7f4b-4536-954b-b5616e8dd821', 'VrkNavCategory-RPF-004', 'Main dishes – Meat'),
                ('de6b17c6-463a-49e6-9dc1-f0dc42507c6d', 'VrkNavCategory-RPF-005', 'Main dishes – Fish'),
                ('12942154-0672-4e48-9789-ed5daf656a0f', 'VrkNavCategory-RPF-006', 'Main dishes – Vegetarian'),
                ('f8eff110-05ee-4b94-96f3-55d934e4521a', 'VrkNavCategory-RPF-007', 'Main dishes – Other'),
                ('5c818977-76b8-4014-a513-26a64d207d06', 'VrkNavCategory-RPF-008', 'Side Dishes'),
                ('39de8ea0-b0d8-4c66-8516-e1c55ee6a6bb', 'VrkNavCategory-RPF-009', 'Sauces, Dips and Spreads – Sweet'),
                ('66b44fe0-2a7a-448c-a75f-0882754030d9', 'VrkNavCategory-RPF-011', 'Desserts and Sweets'),
                ('4e6c95d6-849e-4e0e-8a37-c93af32ed540', 'VrkNavCategory-RPF-012', 'Baking – Savory'),
                ('f7278ad5-3d3c-4912-b42d-92487e1fbbe9', 'VrkNavCategory-RPF-013', 'Baking – Sweet'),
                ('21b494af-71fd-4da8-a42c-921e94453b95', 'VrkNavCategory-RPF-014', 'Breads and Rolls'),
                ('8a3e3682-a69c-4f58-bcca-94ff48de8b5f', 'VrkNavCategory-RPF-015', 'Drinks'),
                ('c93a8d27-d348-4eae-a989-067aca6fc869', 'VrkNavCategory-RPF-016', 'Basics'),
                ('b4761e36-4e96-43ae-802e-53595420a52b', 'VrkNavCategory-RPF-017', 'Baby food'),
                ('73dd6368-5c3f-4840-aa67-7ecb4bb5aaa9', 'VrkNavCategory-RPF-018', 'Sauces, Dips and Spreads – Savory'),
                ('91957ae5-bf50-4d48-9839-d284ea778c26', 'VrkNavCategory-RPF-019', 'Breakfast'),
                ('af15b6fc-03d1-4c90-bc86-37bb1fdd1ed8', 'VrkNavCategory-RPF-020', 'Snacks'),
                ('2c6e2238-4fb0-4eb7-913f-7571351e1a7f', 'VrkNavigationCategory-rpf-000001303095', 'Menus and More')
            on conflict do nothing;
            """);
        
        logger.LogInformation("Initialized db");
        logger.LogError("Initialized db");
    }
}
