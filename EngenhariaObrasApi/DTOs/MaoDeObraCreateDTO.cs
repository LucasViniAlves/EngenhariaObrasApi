using System.ComponentModel.DataAnnotations;

namespace EngenhariaObrasApi.DTOs
{
    public class MaoDeObraCreateDTO
    {
        [Required]
        public string Profissional { get; set; }

        [Required]
        public decimal ValorHora { get; set; }

        [Required]
        public int HorasTrabalhadas { get; set; }

        [Required]
        public int ObraId { get; set; }
    }
}
