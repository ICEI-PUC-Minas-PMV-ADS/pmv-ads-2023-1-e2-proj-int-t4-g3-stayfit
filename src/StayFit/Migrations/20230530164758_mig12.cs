using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Migrations
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstrutorId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstrutorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_InstrutorId",
                table: "Usuarios",
                column: "InstrutorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InstrutorId",
                table: "AspNetUsers",
                column: "InstrutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Instrutores_InstrutorId",
                table: "AspNetUsers",
                column: "InstrutorId",
                principalTable: "Instrutores",
                principalColumn: "InstrutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Instrutores_InstrutorId",
                table: "Usuarios",
                column: "InstrutorId",
                principalTable: "Instrutores",
                principalColumn: "InstrutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Instrutores_InstrutorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Instrutores_InstrutorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_InstrutorId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InstrutorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstrutorId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "InstrutorId",
                table: "AspNetUsers");
        }
    }
}
