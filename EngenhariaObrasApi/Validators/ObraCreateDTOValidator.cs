using FluentValidation;
using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Validators
{
    public class ObraCreateDTOValidator : AbstractValidator<ObraCreateDTO>
    {
        public ObraCreateDTOValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(x => x.Responsavel).NotEmpty().WithMessage("O responsável é obrigatório.");
            RuleFor(x => x.CustoEstimado).GreaterThan(0).WithMessage("Custo estimado deve ser maior que zero.");
        }
    }
}
