using System.ComponentModel.DataAnnotations.Schema;

namespace EngenhariaObrasApi.Models
{
    public class BDI
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(5,2)")] public decimal AdministracaoCentral { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal AdministracaoLocal { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal DespesasIndiretas { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal DespesaFinanceira { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal PosObras { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal Risco { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal Impostos { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal MargemLucro { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal Seguro { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal ReservaTecnica { get; set; }

        // Relacionamento 1:1 com Obra
        public int ObraId { get; set; }
        public Obra? Obra { get; set; }
    }
}
