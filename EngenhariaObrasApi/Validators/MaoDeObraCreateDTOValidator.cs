using FluentValidation;
using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Validators
{
    public class MaoDeObraCreateDTOValidator : AbstractValidator<MaoDeObraCreateDTO>
    {
        public MaoDeObraCreateDTOValidator()
        {
            RuleFor(x => x.Profissional).NotEmpty();
            RuleFor(x => x.ValorHora).GreaterThan(0);
            RuleFor(x => x.HorasTrabalhadas).GreaterThan(0);
            RuleFor(x => x.ObraId).GreaterThan(0);
        }
    }
}
