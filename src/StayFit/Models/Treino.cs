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
        [Required]
        public int RepetitionNumber { get; set; }

        [Display(Name = "Número de Séries")]
        [DefaultValue((int)1)]
        [Required]
        public int Series { get; set; }

        [Display(Name = "Tempo de Descanço")]
        [DefaultValue((int)0)]
        public int? RestTime { get; set; }

        [Display(Name = "Descanço entre Exercícios")]
        [DefaultValue((int)0)]
        public int? RestBetween { get; set; }

        [Display(Name = "Distancia Percorida")]
        [DefaultValue((int)0)]
        public float? Distance { get; set; }

        [Display(Name = "Carga Utilizada")]
        [DefaultValue(0)]
        public float? Weight { get; set; }

        [Display(Name ="Exercício")]
        [Required]
        public int ExercicioId { get; set; }

        public int FichaId { get; set; }
       // public Exercicio? Exercicio { get; set; }

        //public Ficha? Ficha { get; set; }
    }
}

//   "DefaultConnection": "Server=localhost,1433; Initial Catalog=StayFit; User ID=sa ; Password=pauloosilas@1; TrustServerCertificate=True"
//    "DefaultConnection": "Server=tcp:stayfit.database.windows.net,1433;Initial Catalog=stayfit;Persist Security Info=False;User ID=stayfit;Password=Stay@Fit;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",