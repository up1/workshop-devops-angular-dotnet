using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/seed/product1/200/200", "Product 1", 11.49 },
                    { 2, "https://picsum.photos/seed/product2/200/200", "Product 2", 12.99 },
                    { 3, "https://picsum.photos/seed/product3/200/200", "Product 3", 14.49 },
                    { 4, "https://picsum.photos/seed/product4/200/200", "Product 4", 15.99 },
                    { 5, "https://picsum.photos/seed/product5/200/200", "Product 5", 17.489999999999998 },
                    { 6, "https://picsum.photos/seed/product6/200/200", "Product 6", 18.989999999999998 },
                    { 7, "https://picsum.photos/seed/product7/200/200", "Product 7", 20.489999999999998 },
                    { 8, "https://picsum.photos/seed/product8/200/200", "Product 8", 21.989999999999998 },
                    { 9, "https://picsum.photos/seed/product9/200/200", "Product 9", 23.489999999999998 },
                    { 10, "https://picsum.photos/seed/product10/200/200", "Product 10", 24.989999999999998 },
                    { 11, "https://picsum.photos/seed/product11/200/200", "Product 11", 26.489999999999998 },
                    { 12, "https://picsum.photos/seed/product12/200/200", "Product 12", 27.989999999999998 },
                    { 13, "https://picsum.photos/seed/product13/200/200", "Product 13", 29.489999999999998 },
                    { 14, "https://picsum.photos/seed/product14/200/200", "Product 14", 30.989999999999998 },
                    { 15, "https://picsum.photos/seed/product15/200/200", "Product 15", 32.490000000000002 },
                    { 16, "https://picsum.photos/seed/product16/200/200", "Product 16", 33.990000000000002 },
                    { 17, "https://picsum.photos/seed/product17/200/200", "Product 17", 35.490000000000002 },
                    { 18, "https://picsum.photos/seed/product18/200/200", "Product 18", 36.990000000000002 },
                    { 19, "https://picsum.photos/seed/product19/200/200", "Product 19", 38.490000000000002 },
                    { 20, "https://picsum.photos/seed/product20/200/200", "Product 20", 39.990000000000002 },
                    { 21, "https://picsum.photos/seed/product21/200/200", "Product 21", 41.490000000000002 },
                    { 22, "https://picsum.photos/seed/product22/200/200", "Product 22", 42.990000000000002 },
                    { 23, "https://picsum.photos/seed/product23/200/200", "Product 23", 44.490000000000002 },
                    { 24, "https://picsum.photos/seed/product24/200/200", "Product 24", 45.990000000000002 },
                    { 25, "https://picsum.photos/seed/product25/200/200", "Product 25", 47.490000000000002 },
                    { 26, "https://picsum.photos/seed/product26/200/200", "Product 26", 48.990000000000002 },
                    { 27, "https://picsum.photos/seed/product27/200/200", "Product 27", 50.490000000000002 },
                    { 28, "https://picsum.photos/seed/product28/200/200", "Product 28", 51.990000000000002 },
                    { 29, "https://picsum.photos/seed/product29/200/200", "Product 29", 53.490000000000002 },
                    { 30, "https://picsum.photos/seed/product30/200/200", "Product 30", 54.990000000000002 },
                    { 31, "https://picsum.photos/seed/product31/200/200", "Product 31", 56.490000000000002 },
                    { 32, "https://picsum.photos/seed/product32/200/200", "Product 32", 57.990000000000002 },
                    { 33, "https://picsum.photos/seed/product33/200/200", "Product 33", 59.490000000000002 },
                    { 34, "https://picsum.photos/seed/product34/200/200", "Product 34", 60.990000000000002 },
                    { 35, "https://picsum.photos/seed/product35/200/200", "Product 35", 62.490000000000002 },
                    { 36, "https://picsum.photos/seed/product36/200/200", "Product 36", 63.990000000000002 },
                    { 37, "https://picsum.photos/seed/product37/200/200", "Product 37", 65.489999999999995 },
                    { 38, "https://picsum.photos/seed/product38/200/200", "Product 38", 66.989999999999995 },
                    { 39, "https://picsum.photos/seed/product39/200/200", "Product 39", 68.489999999999995 },
                    { 40, "https://picsum.photos/seed/product40/200/200", "Product 40", 69.989999999999995 },
                    { 41, "https://picsum.photos/seed/product41/200/200", "Product 41", 71.489999999999995 },
                    { 42, "https://picsum.photos/seed/product42/200/200", "Product 42", 72.989999999999995 },
                    { 43, "https://picsum.photos/seed/product43/200/200", "Product 43", 74.489999999999995 },
                    { 44, "https://picsum.photos/seed/product44/200/200", "Product 44", 75.989999999999995 },
                    { 45, "https://picsum.photos/seed/product45/200/200", "Product 45", 77.489999999999995 },
                    { 46, "https://picsum.photos/seed/product46/200/200", "Product 46", 78.989999999999995 },
                    { 47, "https://picsum.photos/seed/product47/200/200", "Product 47", 80.489999999999995 },
                    { 48, "https://picsum.photos/seed/product48/200/200", "Product 48", 81.989999999999995 },
                    { 49, "https://picsum.photos/seed/product49/200/200", "Product 49", 83.489999999999995 },
                    { 50, "https://picsum.photos/seed/product50/200/200", "Product 50", 84.989999999999995 },
                    { 51, "https://picsum.photos/seed/product51/200/200", "Product 51", 86.489999999999995 },
                    { 52, "https://picsum.photos/seed/product52/200/200", "Product 52", 87.989999999999995 },
                    { 53, "https://picsum.photos/seed/product53/200/200", "Product 53", 89.489999999999995 },
                    { 54, "https://picsum.photos/seed/product54/200/200", "Product 54", 90.989999999999995 },
                    { 55, "https://picsum.photos/seed/product55/200/200", "Product 55", 92.489999999999995 },
                    { 56, "https://picsum.photos/seed/product56/200/200", "Product 56", 93.989999999999995 },
                    { 57, "https://picsum.photos/seed/product57/200/200", "Product 57", 95.489999999999995 },
                    { 58, "https://picsum.photos/seed/product58/200/200", "Product 58", 96.989999999999995 },
                    { 59, "https://picsum.photos/seed/product59/200/200", "Product 59", 98.489999999999995 },
                    { 60, "https://picsum.photos/seed/product60/200/200", "Product 60", 99.989999999999995 },
                    { 61, "https://picsum.photos/seed/product61/200/200", "Product 61", 101.48999999999999 },
                    { 62, "https://picsum.photos/seed/product62/200/200", "Product 62", 102.98999999999999 },
                    { 63, "https://picsum.photos/seed/product63/200/200", "Product 63", 104.48999999999999 },
                    { 64, "https://picsum.photos/seed/product64/200/200", "Product 64", 105.98999999999999 },
                    { 65, "https://picsum.photos/seed/product65/200/200", "Product 65", 107.48999999999999 },
                    { 66, "https://picsum.photos/seed/product66/200/200", "Product 66", 108.98999999999999 },
                    { 67, "https://picsum.photos/seed/product67/200/200", "Product 67", 110.48999999999999 },
                    { 68, "https://picsum.photos/seed/product68/200/200", "Product 68", 111.98999999999999 },
                    { 69, "https://picsum.photos/seed/product69/200/200", "Product 69", 113.48999999999999 },
                    { 70, "https://picsum.photos/seed/product70/200/200", "Product 70", 114.98999999999999 },
                    { 71, "https://picsum.photos/seed/product71/200/200", "Product 71", 116.48999999999999 },
                    { 72, "https://picsum.photos/seed/product72/200/200", "Product 72", 117.98999999999999 },
                    { 73, "https://picsum.photos/seed/product73/200/200", "Product 73", 119.48999999999999 },
                    { 74, "https://picsum.photos/seed/product74/200/200", "Product 74", 120.98999999999999 },
                    { 75, "https://picsum.photos/seed/product75/200/200", "Product 75", 122.48999999999999 },
                    { 76, "https://picsum.photos/seed/product76/200/200", "Product 76", 123.98999999999999 },
                    { 77, "https://picsum.photos/seed/product77/200/200", "Product 77", 125.48999999999999 },
                    { 78, "https://picsum.photos/seed/product78/200/200", "Product 78", 126.98999999999999 },
                    { 79, "https://picsum.photos/seed/product79/200/200", "Product 79", 128.49000000000001 },
                    { 80, "https://picsum.photos/seed/product80/200/200", "Product 80", 129.99000000000001 },
                    { 81, "https://picsum.photos/seed/product81/200/200", "Product 81", 131.49000000000001 },
                    { 82, "https://picsum.photos/seed/product82/200/200", "Product 82", 132.99000000000001 },
                    { 83, "https://picsum.photos/seed/product83/200/200", "Product 83", 134.49000000000001 },
                    { 84, "https://picsum.photos/seed/product84/200/200", "Product 84", 135.99000000000001 },
                    { 85, "https://picsum.photos/seed/product85/200/200", "Product 85", 137.49000000000001 },
                    { 86, "https://picsum.photos/seed/product86/200/200", "Product 86", 138.99000000000001 },
                    { 87, "https://picsum.photos/seed/product87/200/200", "Product 87", 140.49000000000001 },
                    { 88, "https://picsum.photos/seed/product88/200/200", "Product 88", 141.99000000000001 },
                    { 89, "https://picsum.photos/seed/product89/200/200", "Product 89", 143.49000000000001 },
                    { 90, "https://picsum.photos/seed/product90/200/200", "Product 90", 144.99000000000001 },
                    { 91, "https://picsum.photos/seed/product91/200/200", "Product 91", 146.49000000000001 },
                    { 92, "https://picsum.photos/seed/product92/200/200", "Product 92", 147.99000000000001 },
                    { 93, "https://picsum.photos/seed/product93/200/200", "Product 93", 149.49000000000001 },
                    { 94, "https://picsum.photos/seed/product94/200/200", "Product 94", 150.99000000000001 },
                    { 95, "https://picsum.photos/seed/product95/200/200", "Product 95", 152.49000000000001 },
                    { 96, "https://picsum.photos/seed/product96/200/200", "Product 96", 153.99000000000001 },
                    { 97, "https://picsum.photos/seed/product97/200/200", "Product 97", 155.49000000000001 },
                    { 98, "https://picsum.photos/seed/product98/200/200", "Product 98", 156.99000000000001 },
                    { 99, "https://picsum.photos/seed/product99/200/200", "Product 99", 158.49000000000001 },
                    { 100, "https://picsum.photos/seed/product100/200/200", "Product 100", 159.99000000000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
