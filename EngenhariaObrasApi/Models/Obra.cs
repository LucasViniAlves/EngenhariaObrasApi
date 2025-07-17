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
        public string? NomeCliente { get; set; }
        public string? IdentidadeCliente { get; set; }
        public string? emailCliente { get; set; }
        public string? local { get; set; }
        public decimal areaTotal { get; set; }
        public string? tipoObra { get; set; }
        public string? faseAtual { get; set; }
        public string? engenheiro { get; set; }
        public string? observacoes { get; set; }

        // Relacionamentos corretos
        public List<Material> Materiais { get; set; }
        public List<MaoDeObra> MaoDeObras { get; set; }
        public List<CustoAdicional> CustosAdicionais { get; set; }
        public BDI BDI { get; set; }
        public ICollection<ObrasMateriais> ObrasMateriais { get; set; } = new List<ObrasMateriais>();

    }
}
