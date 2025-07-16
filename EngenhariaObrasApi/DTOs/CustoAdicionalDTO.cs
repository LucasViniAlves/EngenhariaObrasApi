namespace EngenhariaObrasApi.DTOs
{
    public class CustoAdicionalDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int ObraId { get; set; }
    }
}
