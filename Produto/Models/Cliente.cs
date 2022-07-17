using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produto.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        [Display(Name = "Cpf")]
        [Column("Cpf")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data Nascimento")]
        [Column("DataNascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        [Column("Telefone")]
        public string Telefone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        public List<Endereco> Enderecos { get; set; }
    }
}
