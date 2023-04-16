using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayFit.Models
{
    [Table("Treinos")]
    public class Treino
    {
        [Key]
        public int TreinoId { get; set; }      
        
        [Display(Name = "Número de Repetições")]
        [DefaultValue((int)1)]
        public int RepetitionNumber { get; set; }

        [Display(Name = "Número de Séries")]
        [DefaultValue((int)1)]
        public int Series { get; set; }

        [Display(Name = "Tempo de Descanço")]
        [DefaultValue((int)1)]
        public int RestTime { get; set; }

        [Display(Name = "Dia da Semana")]
        public DiaSemana DiaSemana { get; set; }

        [Display(Name = "Data de Inicio")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data do Fim")]
        public DateTime DataFim { get; set; }

        [Display(Name = "Distancia Percorida")]
        [DefaultValue((int)0)]
        public float Distance { get; set; }

        [Display(Name = "Carga Utilizada")]
        [DefaultValue(0)]
        public float Weight { get; set; }

        public int ExercicioId { get; set; }
        [ForeignKey("ExercicioId")]
        public IEnumerable<Exercicio> Exercicios { get; set; }

    }
}

//    "DefaultConnection": "Server=tcp:stayfit.database.windows.net,1433;Initial Catalog=stayfit;Persist Security Info=False;User ID=stayfit;Password=Stay@Fit;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",