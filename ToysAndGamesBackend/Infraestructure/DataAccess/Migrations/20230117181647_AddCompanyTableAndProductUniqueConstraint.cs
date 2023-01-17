using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyTableAndProductUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_Id",
                table: "Company",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Company_Id",
                table: "Company");
        }
    }
}
