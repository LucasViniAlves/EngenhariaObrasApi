using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngenhariaObrasApi.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        public int Quantidade { get; set; }
        public ICollection<ObrasMateriais> ObrasMateriais { get; set; } = new List<ObrasMateriais>();

    }
}
