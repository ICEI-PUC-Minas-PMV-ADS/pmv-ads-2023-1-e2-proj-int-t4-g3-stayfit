using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StayFit.Models
{
	public class ApplicationUser:IdentityUser
	{
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
		}
}
