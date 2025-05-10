using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakeryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var mainOffice = "Main Office";
            var secondaryOffice = "Secondary Office";
            migrationBuilder.InsertData(
                table: "BakeryOffices",
                columns: new[] { "Id", "Name", "Capacity", "Address", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, mainOffice, 150, "123 Main Street", "555-1234" },
                    { 2, secondaryOffice, 100, "456 Elm Street", "555-5678" },
                }
            );

            // Insertar datos en Bread
            migrationBuilder.InsertData(
                table: "Breads",
                columns: new[]
                {
                    "Id",
                    "Name",
                    "Price",
                    "CookingTime",
                    "RestingTime",
                    "FermentTime",
                    "Temperature",
                },
                values: new object[,]
                {
                    {
                        1,
                        "Baguette",
                        2.0,
                        TimeSpan.FromMinutes(15),
                        TimeSpan.FromMinutes(30),
                        TimeSpan.FromDays(1),
                        270.0,
                    },
                    {
                        2,
                        "White Bread",
                        2.5,
                        TimeSpan.FromMinutes(30),
                        TimeSpan.FromHours(1),
                        TimeSpan.FromHours(4),
                        180.0,
                    },
                    {
                        3,
                        "Milk Bread",
                        1.5,
                        TimeSpan.FromMinutes(15),
                        TimeSpan.FromMinutes(10),
                        TimeSpan.FromHours(4),
                        180.0,
                    },
                    {
                        4,
                        "Hamburger Bun",
                        1.0,
                        TimeSpan.FromMinutes(15),
                        TimeSpan.FromMinutes(30),
                        TimeSpan.FromHours(4),
                        180.0,
                    },
                }
            );
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Quantity", "Unit", "BreadId" },
                values: new object[,]
                {
                    // Ingredientes de Baguette
                    { 1, "Flour", 280.0, "g", 1 },
                    { 2, "Water", 210.0, "g", 1 },
                    { 3, "Salt", 10.0, "g", 1 },
                    { 4, "Yeast", 5.0, "g", 1 },
                    // Ingredientes de White Bread
                    { 5, "Flour", 1000.0, "g", 2 },
                    { 6, "Water", 280.0, "g", 2 },
                    { 7, "Salt", 20.0, "g", 2 },
                    { 8, "Yeast", 20.0, "g", 2 },
                    { 9, "Sugar", 80.0, "g", 2 },
                    { 10, "Milk", 60.0, "g", 2 },
                    { 11, "Butter", 100.0, "g", 2 },
                    // Ingredientes de Milk Bread
                    { 12, "Flour", 55.0, "g", 3 },
                    { 13, "Water", 25.0, "g", 3 },
                    { 14, "Salt", 1.0, "g", 3 },
                    { 15, "Yeast", 3.0, "g", 3 },
                    { 16, "Sugar", 6.0, "g", 3 },
                    { 17, "Egg", 10.0, "g", 3 },
                    { 18, "Milk", 20.0, "g", 3 },
                    { 19, "Butter", 10.0, "g", 3 },
                    { 20, "Honey", 2.0, "g", 3 },
                    { 21, "Lemon zest", 1.0, "g", 3 },
                    { 22, "Vanilla essence", 1.0, "g", 3 },
                    // Ingredientes de Hamburger Bun
                    { 23, "Flour", 100.0, "g", 4 },
                    { 24, "Water", 25.0, "g", 4 },
                    { 25, "Salt", 2.0, "g", 4 },
                    { 26, "Yeast", 4.0, "g", 4 },
                    { 27, "Sugar", 6.0, "g", 4 },
                    { 28, "Egg", 10.0, "g", 4 },
                    { 29, "Milk", 5.0, "g", 4 },
                    { 30, "Butter", 6.0, "g", 4 },
                    { 31, "Sweet potato", 25.0, "g", 4 },
                    { 32, "Sesame seed", 10.0, "g", 4 },
                    { 33, "Gilding", 5.0, "g", 4 },
                }
            );

            // Insertar datos en Menu
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "BreadId", "BakeryOfficeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 4, 2 },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BakeryOffices",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2 }
            );

            migrationBuilder.DeleteData(
                table: "Breads",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 }
            );

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    13,
                    14,
                    15,
                    16,
                    17,
                    18,
                    19,
                    20,
                    21,
                    22,
                    23,
                    24,
                    25,
                    26,
                    27,
                    28,
                    29,
                    30,
                    31,
                    32,
                    33,
                }
            );

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6 }
            );
        }
    }
}
