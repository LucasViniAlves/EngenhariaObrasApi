namespace EngenhariaObrasApi.DTOs
{
    public class BDIDTO
    {
        public int Id { get; set; }
        public decimal AdministracaoCentral { get; set; }
        public decimal AdministracaoLocal { get; set; }
        public decimal DespesasIndiretas { get; set; }
        public decimal DespesaFinanceira { get; set; }
        public decimal PosObras { get; set; }
        public decimal Risco { get; set; }
        public decimal Impostos { get; set; }
        public decimal MargemLucro { get; set; }
        public decimal Seguro { get; set; }
        public decimal ReservaTecnica { get; set; }
        public int ObraId { get; set; }
    }
}
