using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayFit.Models
{
    [Table("Exercicios")]
    public class Exercicio
    {
        [Key]
        public int ExercicioId { get; set; }

        [Required(ErrorMessage = "O nome do exercício deve ser informado!")]
        [Display(Name = "Nome do Exercício")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O Nome deve ter no minimo 10 e no maximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição deve ser informada!")]
        [Display(Name = "Descrição")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "A Descrição deve ter no minimo 20 caracteres e maximo 500 caracteres")]
        public string Description { get; set; }

        [Display(Name = "Caminho da Imagem")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? Photo { get; set; }

        [Display(Name = "Caminho do Video")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string? Video { get; set; }

        [Display(Name = "Grupo Muscular")]
        public GroupMuscle GroupMuscle { get; set; }

        [Display(Name = "Tipo de Exercicio")]
        [Required(ErrorMessage = "Informe se o exercício é Muscular ou Aeróbico")]
        public TypeExercice TypeExercice { get; set; }

    }
}
