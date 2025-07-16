namespace EngenhariaObrasApi.DTOs
{
    public class MaoDeObraDTO
    {
        public int Id { get; set; }
        public string Profissional { get; set; }
        public decimal ValorHora { get; set; }
        public int HorasTrabalhadas { get; set; }
        public int ObraId { get; set; }
    }
}
