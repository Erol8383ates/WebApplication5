using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class Migggg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectieschermBeamer",
                table: "Products",
                newName: "Projectiescherm");

            migrationBuilder.RenameColumn(
                name: "Merk",
                table: "Products",
                newName: "MerkModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Projectiescherm",
                table: "Products",
                newName: "ProjectieschermBeamer");

            migrationBuilder.RenameColumn(
                name: "MerkModel",
                table: "Products",
                newName: "Merk");
        }
    }
}
