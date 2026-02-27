using ControleFinanceiro.Application.Users.Commands.LoginUsuario;
using FluentValidation;

namespace ControleFinanceiro.Application.Users.Validators;

public sealed class LoginUsuarioCommandValidator : AbstractValidator<LoginUsuarioCommand>
{
    public LoginUsuarioCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail é obrigatório.")
            .EmailAddress().WithMessage("E-mail inválido.");

        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("Senha é obrigatória.");
    }
}
