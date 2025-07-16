using System.ComponentModel.DataAnnotations;

namespace EngenhariaObrasApi.DTOs
{
    public class ObraCreateDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Responsavel { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public decimal CustoEstimado { get; set; }
    }
}
