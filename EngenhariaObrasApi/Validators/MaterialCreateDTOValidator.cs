using FluentValidation;
using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Validators
{
    public class MaterialCreateDTOValidator : AbstractValidator<MaterialCreateDTO>
    {
        public MaterialCreateDTOValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.PrecoUnitario).GreaterThan(0);
            RuleFor(x => x.Quantidade).GreaterThan(0);
        }
    }
}
