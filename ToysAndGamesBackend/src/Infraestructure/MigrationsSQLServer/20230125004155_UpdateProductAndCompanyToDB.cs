using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.MigrationsSQLServer
{
    /// <inheritdoc />
    public partial class UpdateProductAndCompanyToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgeRestriction = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("87eeb61c-8f5b-4eb7-a6f0-d699de65c9d2"), "Mattel" },
                    { new Guid("9995512f-3255-4468-952f-c06d9c89d656"), "Hasbro" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AgeRestriction", "CompanyId", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1d77b12f-5cb3-4651-b1e4-be186de93286"), 6, new Guid("87eeb61c-8f5b-4eb7-a6f0-d699de65c9d2"), "MaxSteel vs Elementor", "https://www.cinepremiere.com.mx/wp-content/uploads/2020/04/Max-Steel-ranking-.jpg", "MaxSteel", 205.85m },
                    { new Guid("7fbacefc-3380-44fd-b73f-9a3f212a2f46"), 10, new Guid("9995512f-3255-4468-952f-c06d9c89d656"), "Nonopoly Marvel", "https://phantom-elmundo.unidadeditorial.es/8faa10a4f45cce9370d6f3d9d3632ea9/crop/0x213/1198x1009/resize/640/assets/multimedia/imagenes/2020/04/16/15870484935240.jpg", "Monopoly", 498.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Id",
                table: "Company",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CompanyId",
                table: "Product",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                table: "Product",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
