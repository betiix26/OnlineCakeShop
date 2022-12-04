using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCakeShop.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "CustomCakes",
                columns: table => new
                {
                    CustomCakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chocolate = table.Column<bool>(type: "bit", nullable: false),
                    Peanuts = table.Column<bool>(type: "bit", nullable: false),
                    Apples = table.Column<bool>(type: "bit", nullable: false),
                    Raspberries = table.Column<bool>(type: "bit", nullable: false),
                    WhippedCream = table.Column<bool>(type: "bit", nullable: false),
                    Snickers = table.Column<bool>(type: "bit", nullable: false),
                    Coconut = table.Column<bool>(type: "bit", nullable: false),
                    Cookies = table.Column<bool>(type: "bit", nullable: false),
                    Cherry = table.Column<bool>(type: "bit", nullable: false),
                    Strawberries = table.Column<bool>(type: "bit", nullable: false),
                    Vanilla = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCakes", x => x.CustomCakeId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Cakes",
                columns: table => new
                {
                    CakeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.CakeId);
                    table.ForeignKey(
                        name: "FK_Cakes_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_Cakes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Quantities",
                columns: table => new
                {
                    QuantityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    CakeId = table.Column<int>(type: "int", nullable: true),
                    CustomCakeId = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantities", x => x.QuantityId);
                    table.ForeignKey(
                        name: "FK_Quantities_Cakes_CakeId",
                        column: x => x.CakeId,
                        principalTable: "Cakes",
                        principalColumn: "CakeId");
                    table.ForeignKey(
                        name: "FK_Quantities_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_Quantities_CustomCakes_CustomCakeId",
                        column: x => x.CustomCakeId,
                        principalTable: "CustomCakes",
                        principalColumn: "CustomCakeId");
                    table.ForeignKey(
                        name: "FK_Quantities_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CakeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Cakes_CakeId",
                        column: x => x.CakeId,
                        principalTable: "Cakes",
                        principalColumn: "CakeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_CartId",
                table: "Cakes",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_CategoryId",
                table: "Cakes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Quantities_CakeId",
                table: "Quantities",
                column: "CakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quantities_CartId",
                table: "Quantities",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Quantities_CustomCakeId",
                table: "Quantities",
                column: "CustomCakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quantities_OrderId",
                table: "Quantities",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CakeId",
                table: "Reviews",
                column: "CakeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Quantities");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "CustomCakes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cakes");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
