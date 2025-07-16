using System.ComponentModel.DataAnnotations;

namespace EngenhariaObrasApi.DTOs
{
    public class BDICreateDTO
    {
        [Required] 
        public decimal AdministracaoCentral { get; set; }
        
        [Required] 
        public decimal AdministracaoLocal { get; set; }
        
        [Required] 
        public decimal DespesasIndiretas { get; set; }
        
        [Required] 
        public decimal DespesaFinanceira { get; set; }
        
        [Required] 
        public decimal PosObras { get; set; }
        
        [Required] 
        public decimal Risco { get; set; }
        
        [Required] 
        public decimal Impostos { get; set; }
        
        [Required] 
        public decimal MargemLucro { get; set; }
        
        [Required] 
        public decimal Seguro { get; set; }
        
        [Required] 
        public decimal ReservaTecnica { get; set; }
        
        [Required] 
        public int ObraId { get; set; }
    }
}
