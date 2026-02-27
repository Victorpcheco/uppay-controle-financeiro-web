using ControleFinanceiro.Application.Dtos;
using FluentValidation;

namespace ControleFinanceiro.Application.Validators;

public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Email inválido.");

        RuleFor(x => x.SenhaHash)
            .NotEmpty().WithMessage("Senha é obrigatória.");
    }
}