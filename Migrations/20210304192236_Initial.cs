using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureStorage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    foto = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    marca = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    edicion = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    activa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogos");
        }
    }
}
