using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CircunferenciaAntiBracoDir",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "CircunferenciaAntiBracoEsq",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "Cirurgia",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "IsFezCirurgia",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<float>(
                name: "PercentualGordura",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaQuadril",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaPernaEsq",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaPernaDir",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaCoxaEsq",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaCoxaDir",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaCintura",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaBracoEsq",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaBracoDir",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaAbdomen",
                table: "Avaliacoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "CircunferenciaAnteBracoDir",
                table: "Avaliacoes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CircunferenciaAnteBracoEsq",
                table: "Avaliacoes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAvaliacao",
                table: "Avaliacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FrecCardM1",
                table: "Avaliacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrecCardM2",
                table: "Avaliacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrecCardM3",
                table: "Avaliacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrecCardMaxima",
                table: "Avaliacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrecCardRepouso",
                table: "Avaliacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MassaGorda",
                table: "Avaliacoes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MassaMagra",
                table: "Avaliacoes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MassaMuscular",
                table: "Avaliacoes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MassaOssea",
                table: "Avaliacoes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MassaResidual",
                table: "Avaliacoes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objetivos",
                table: "Avaliacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "TempoEsteira",
                table: "Avaliacoes",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "VoMax",
                table: "Avaliacoes",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CircunferenciaAnteBracoDir",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "CircunferenciaAnteBracoEsq",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "DataAvaliacao",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "FrecCardM1",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "FrecCardM2",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "FrecCardM3",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "FrecCardMaxima",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "FrecCardRepouso",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "MassaGorda",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "MassaMagra",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "MassaMuscular",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "MassaOssea",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "MassaResidual",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "Objetivos",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "TempoEsteira",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "VoMax",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<float>(
                name: "PercentualGordura",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaQuadril",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaPernaEsq",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaPernaDir",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaCoxaEsq",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaCoxaDir",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaCintura",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaBracoEsq",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaBracoDir",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CircunferenciaAbdomen",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CircunferenciaAntiBracoDir",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CircunferenciaAntiBracoEsq",
                table: "Avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Cirurgia",
                table: "Avaliacoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFezCirurgia",
                table: "Avaliacoes",
                type: "bit",
                nullable: true);
        }
    }
}
