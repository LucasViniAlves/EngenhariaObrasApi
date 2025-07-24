namespace EngenhariaObrasApi.DTOs
{
    public class OrcamentoRequestDTO
    {
        public string TipoObra { get; set; } = string.Empty;
        public double Area { get; set; }
        public string Local { get; set; } = string.Empty;
        public int PrazoDias { get; set; }
    }
}
