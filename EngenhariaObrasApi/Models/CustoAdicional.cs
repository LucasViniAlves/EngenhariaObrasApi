using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngenhariaObrasApi.Models
{
    public class CustoAdicional
    {
        public int Id { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        public int ObraId { get; set; }

        public Obra? Obra { get; set; }
    }
}
