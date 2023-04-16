using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayFit.Models
{
    [Table("Fichas")]
    public class Ficha
    {
        [Key]
        public int FichaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public IEnumerable<Treino> Treinos { get; set; }
    }
}
