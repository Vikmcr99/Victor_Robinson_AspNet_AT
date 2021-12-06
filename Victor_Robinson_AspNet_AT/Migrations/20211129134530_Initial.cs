using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Victor_Robinson_AspNet_AT.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aniversariante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aniversariante", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aniversariante");
        }
    }
}
