using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Exercicios_ExercicioId",
                table: "Treinos");

            migrationBuilder.AlterColumn<int>(
                name: "ExercicioId",
                table: "Treinos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Exercicios_ExercicioId",
                table: "Treinos",
                column: "ExercicioId",
                principalTable: "Exercicios",
                principalColumn: "ExercicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Exercicios_ExercicioId",
                table: "Treinos");

            migrationBuilder.AlterColumn<int>(
                name: "ExercicioId",
                table: "Treinos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Exercicios_ExercicioId",
                table: "Treinos",
                column: "ExercicioId",
                principalTable: "Exercicios",
                principalColumn: "ExercicioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
