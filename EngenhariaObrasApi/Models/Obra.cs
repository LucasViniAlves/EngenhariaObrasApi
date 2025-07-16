using System.ComponentModel.DataAnnotations;

namespace EngenhariaObrasApi.Models
{
    public class Obra
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Responsavel { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public decimal CustoEstimado { get; set; }

        // Relacionamentos corretos
        public List<Material> Materiais { get; set; }
        public List<MaoDeObra> MaoDeObras { get; set; }
        public List<CustoAdicional> CustosAdicionais { get; set; }
        public BDI BDI { get; set; }
        public ICollection<ObrasMateriais> ObrasMateriais { get; set; } = new List<ObrasMateriais>();

    }
}
