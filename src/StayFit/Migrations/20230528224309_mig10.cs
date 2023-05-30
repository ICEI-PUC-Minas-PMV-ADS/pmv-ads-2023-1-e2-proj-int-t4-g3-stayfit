using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayFit.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    IsPraticante = table.Column<bool>(type: "bit", nullable: true),
                    IsTomaMedicamentos = table.Column<bool>(type: "bit", nullable: true),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFumante = table.Column<bool>(type: "bit", nullable: true),
                    IsProblemaSaude = table.Column<bool>(type: "bit", nullable: true),
                    ProblemaSaude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFezCirurgia = table.Column<bool>(type: "bit", nullable: true),
                    Cirurgia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeficiente = table.Column<bool>(type: "bit", nullable: true),
                    Deficiencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CircunferenciaBracoDir = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaBracoEsq = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaAntiBracoDir = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaAntiBracoEsq = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaAbdomen = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaQuadril = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaCintura = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaCoxaEsq = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaCoxaDir = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaPernaEsq = table.Column<float>(type: "real", nullable: false),
                    CircunferenciaPernaDir = table.Column<float>(type: "real", nullable: false),
                    PercentualGordura = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.AvaliacaoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");
        }
    }
}
