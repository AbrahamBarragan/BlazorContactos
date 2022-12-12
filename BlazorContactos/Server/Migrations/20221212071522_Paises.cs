using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorContactos.Server.Migrations
{
    public partial class Paises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediosContactoPais",
                columns: table => new
                {
                    PaisesId = table.Column<int>(type: "int", nullable: false),
                    mediosContactosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediosContactoPais", x => new { x.PaisesId, x.mediosContactosId });
                    table.ForeignKey(
                        name: "FK_MediosContactoPais_Medios_mediosContactosId",
                        column: x => x.mediosContactosId,
                        principalTable: "Medios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediosContactoPais_Paises_PaisesId",
                        column: x => x.PaisesId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediosContactoPais_mediosContactosId",
                table: "MediosContactoPais",
                column: "mediosContactosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediosContactoPais");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
