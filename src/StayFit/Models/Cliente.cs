﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayFit.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            Pontuacao = 0;
            Fichas = new List<Ficha>(); 
            NumeroDeTreinos = 0;
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
               
        public int? Matricula { get; set; }


        [Required(ErrorMessage = "Informe o Nome do Cliente")]
        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras, por favor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
           ErrorMessage = "Email com formato incorreto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o CPF do Cliente")]
        [StringLength(11)]
        public string CPF { get; set; }
        public Sexo Sexo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Telefone")]
        [StringLength(15)]
        public string Telefone { get; set; }

      
        public int? Pontuacao { get; set; }
        public int NumeroDeTreinos { get; set; }
       
        [Required(ErrorMessage = "Informe o Nome o Endereço do Cliente")]
        [StringLength(70)]
        [Display(Name = "Endereço")]
        public String Endereco { get; set; }

        [Required(ErrorMessage = "Informe o Bairro do Cliente")]
        [StringLength(30)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o Nome o Número da residencia do Cliente")]
        [Display(Name = "Número")]
        public int Numero { get; set; }
        public IEnumerable<Ficha>? Fichas { get; set; }       


        
    }
}
