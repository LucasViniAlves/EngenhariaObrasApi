using System.ComponentModel.DataAnnotations;

namespace EngenhariaObrasApi.DTOs
{
    public class CustoAdicionalCreateDTO
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public int ObraId { get; set; }
    }
}
