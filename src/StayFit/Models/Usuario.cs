
using System.ComponentModel.DataAnnotations;

namespace StayFit.Models
{
    public class Usuario
    {
        public Usuario()
        {
            TipoUsuario = TypeUser.Cliente;
            Foto = "/site-imagens/user.png";
        }
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Informe o Nome completo")]
        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras, por favor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Adicione uma senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres...")]      
		public string Senha { get; set; }

        public int? Matricula { get; set; }

		[Display(Name = "Foto")]
		[StringLength(200)]
		public string? Foto { get; set; }

		[Required(ErrorMessage = "Informe o email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
          ErrorMessage = "Email com formato incorreto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [StringLength(11)]
        public string CPF { get; set; }
        public TypeUser TipoUsuario { get; set; }
        public Cliente? Cliente { get; set; }

        public Instrutor? Instrutor { get; set; }
    }
}
