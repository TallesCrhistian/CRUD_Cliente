using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produto.Models
{
    public class Endereco
    {

        [Required]
        [Column("Cep")]
        [Display(Name ="Cep")]
        public string Cep { get; set; }

        [Required]
        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required]
        [Column("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required]
        [Column("Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required]
        [Column("Numero")]
        [Display(Name = "Numero")]
        public int Numero { get; set; }
        [Key]
        public string ClienteForeignKey { get; set; }
        public Cliente Cliente { get; set; }
    }
}
