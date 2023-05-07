using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Matricula",
                table: "Clientes",
                type: "int",
                nullable: true,
                computedColumnSql: "CAST(ClienteId + RAND() * 1000 AS INT)",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComputedColumnSql: "CONCAT(1220, ClienteId)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Matricula",
                table: "Clientes",
                type: "int",
                nullable: true,
                computedColumnSql: "CONCAT(1220, ClienteId)",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComputedColumnSql: "CONCAT(120000, ClienteId AS INT)");
        }
    }
}
