using System.ComponentModel.DataAnnotations;

namespace StayFit.Models
{
    public class Avaliacao
    {
        public Avaliacao()
        {
            IsPraticante = false;
            DataAvaliacao = DateTime.Now;
            Objetivos = "Emagrecer";
            Peso = 0;
            Altura = 0;
        }

        [Key]
        public int AvaliacaoId { get; set; }

        public DateTime DataAvaliacao { get; set; }
        public string Objetivos { get; set; }


        [Required(ErrorMessage = "Informe o Peso Corporal do Cliente")]
        public float Peso { get; set; }

        [Required(ErrorMessage = "Informe a Altura do Cliente")]
        public float Altura { get; set; }
        public Boolean? IsPraticante { get; set; }
        public bool? IsTomaMedicamentos { get; set; }
        public String? Medicamentos { get; set; }
        public bool? IsFumante { get; set; }
        public bool? IsProblemaSaude{ get; set; }
        public String? ProblemaSaude { get; set; }      
        public bool? IsDeficiente { get; set; }
        public String? Deficiencia { get; set; }
        public String? Observacoes { get; set; }


        public float? CircunferenciaBracoDir { get; set; }
        public float? CircunferenciaBracoEsq { get; set; }
        public float? CircunferenciaAnteBracoDir { get; set; }
        public float? CircunferenciaAnteBracoEsq { get; set; }
        public float? CircunferenciaAbdomen { get; set; }
        public float? CircunferenciaQuadril { get; set; }
        public float? CircunferenciaCintura { get; set; }
        public float? CircunferenciaCoxaEsq { get; set; }
        public float? CircunferenciaCoxaDir { get; set; }
        public float? CircunferenciaPernaEsq { get; set; }
        public float? CircunferenciaPernaDir { get; set; }

        public float? PercentualGordura { get; set; }
        public float? MassaMagra { get; set; }
        public float? MassaGorda { get; set; }
        public float? MassaMuscular { get; set; }
        public float? MassaOssea { get; set; }
        public float? MassaResidual { get; set; }

        public int? FrecCardRepouso { get; set; }
        public int? FrecCardM1 { get; set; }
        public int? FrecCardM2 { get; set; }
        public int? FrecCardM3 { get; set; }
        public int? FrecCardMaxima { get; set; }

        public float? VoMax { get; set; }


        public float? TempoEsteira { get; set; }
    
    }
}
