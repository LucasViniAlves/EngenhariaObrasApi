using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngenhariaObrasApi.Models
{
    public class MaoDeObra
    {
        public int Id { get; set; }

        [Required]
        public string? Profissional { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorHora { get; set; }

        public int HorasTrabalhadas { get; set; }

        public int ObraId { get; set; }

        public Obra? Obra { get; set; }
    }
}
