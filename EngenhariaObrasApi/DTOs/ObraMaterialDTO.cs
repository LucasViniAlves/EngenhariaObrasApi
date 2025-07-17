using System.ComponentModel.DataAnnotations;

namespace EngenhariaObrasApi.DTOs
{
    public class ObraMaterialDTO
    {
        public int IdMaterial { get; set; }
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
