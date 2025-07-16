using System.ComponentModel.DataAnnotations;

namespace EngenhariaObrasApi.DTOs
{
    public class MaterialCreateDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
