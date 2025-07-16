using FluentValidation;
using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Validators
{
    public class BDICreateDTOValidator : AbstractValidator<BDICreateDTO>
    {
        public BDICreateDTOValidator()
        {
            RuleFor(x => x.AdministracaoCentral)
                .NotNull().WithMessage("Administração Central é obrigatória.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.AdministracaoLocal)
                .NotNull().WithMessage("Administração Local é obrigatória.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.DespesasIndiretas)
                .NotNull().WithMessage("Despesas Indiretas são obrigatórias.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.DespesaFinanceira)
                .NotNull().WithMessage("Despesa Financeira é obrigatória.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.PosObras)
                .NotNull().WithMessage("Pós-Obras é obrigatório.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.Risco)
                .NotNull().WithMessage("Risco é obrigatório.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.Impostos)
                .NotNull().WithMessage("Impostos são obrigatórios.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.MargemLucro)
                .NotNull().WithMessage("Margem de Lucro é obrigatória.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.Seguro)
                .NotNull().WithMessage("Seguro é obrigatório.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");

            RuleFor(x => x.ReservaTecnica)
                .NotNull().WithMessage("Reserva Técnica é obrigatória.")
                .GreaterThanOrEqualTo(0).WithMessage("Deve ser maior ou igual a zero.");
        }
    }
}
