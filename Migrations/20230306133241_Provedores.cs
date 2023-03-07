using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiMonitores.Migrations
{
    /// <inheritdoc />
    public partial class Provedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvedorId",
                table: "Monitores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Provedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compania = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provedores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitores_ProvedorId",
                table: "Monitores",
                column: "ProvedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitores_Provedores_ProvedorId",
                table: "Monitores",
                column: "ProvedorId",
                principalTable: "Provedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitores_Provedores_ProvedorId",
                table: "Monitores");

            migrationBuilder.DropTable(
                name: "Provedores");

            migrationBuilder.DropIndex(
                name: "IX_Monitores_ProvedorId",
                table: "Monitores");

            migrationBuilder.DropColumn(
                name: "ProvedorId",
                table: "Monitores");
        }
    }
}
