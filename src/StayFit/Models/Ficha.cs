using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayFit.Models
{
    [Table("Fichas")]
    public class Ficha
    {
        [Key]
        public int FichaId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Atividade para:")]
        public string NomeAtividade { get; set; }

        [Display(Name ="Dia Da Semana")]
        public DiaSemana? DiaSemana { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Inicio do Treino")]
        public DateTime? DataInicio { get; set; }

        [Display(Name = "Fim do Treino")]
        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }
        public IEnumerable<Treino>? Treinos { get; set; }

        public int? ClienteId { get; set; }

        
    }
}
