namespace EngenhariaObrasApi.DTOs
{
    public class ItemOrcamento
    {
        public string Nome { get; set; } = string.Empty;
        public string Quantidade { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
    }

    public class MaoDeObraEstimativa
    {
        public string Profissional { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int Dias { get; set; }
        public decimal SalarioDiario { get; set; }
    }

    public class OrcamentoResponse
    {
        public List<ItemOrcamento> Materiais { get; set; } = new();
        public List<MaoDeObraEstimativa> MaoDeObra { get; set; } = new();
        public decimal CustoTotalEstimado { get; set; }
    }
}
