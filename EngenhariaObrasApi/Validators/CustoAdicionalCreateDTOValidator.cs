using FluentValidation;
using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Validators
{
    public class CustoAdicionalCreateDTOValidator : AbstractValidator<CustoAdicionalCreateDTO>
    {
        public CustoAdicionalCreateDTOValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty();
            RuleFor(x => x.Valor).GreaterThan(0);
            RuleFor(x => x.ObraId).GreaterThan(0);
        }
    }
}
