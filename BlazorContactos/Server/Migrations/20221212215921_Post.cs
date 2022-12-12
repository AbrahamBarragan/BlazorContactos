using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorContactos.Server.Migrations
{
    public partial class Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Continente",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Continente",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Paises");
        }
    }
}
