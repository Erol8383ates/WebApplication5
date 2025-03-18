using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
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
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lokaal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Merk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Problemen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beamer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBoard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectieschermBeamer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Luidsprekers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opmerkingen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
