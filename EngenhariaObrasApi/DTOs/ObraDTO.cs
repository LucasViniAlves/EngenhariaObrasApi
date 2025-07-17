namespace EngenhariaObrasApi.DTOs
{
    public class ObraDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
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

        // Relacionamentos
        public List<ObraMaterialDTO> Materiais { get; set; }
        public List<MaoDeObraDTO> MaoDeObras { get; set; }
        public List<CustoAdicionalDTO> CustosAdicionais { get; set; }
        public BDIDTO BDI { get; set; }
    }
}
