using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produto.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Column("Cidade")]
        [Display(Name ="Cidade")]
        public string Cidade { get; set; }

        [Column("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Column("Rua")]
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Column("Numero")]
        [Display(Name = "Numero")]
        public int Numero { get; set; }

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
