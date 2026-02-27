using ControleFinanceiro.Application.Behaviors;
using ControleFinanceiro.Application.Users.Validators;
using ControleFinanceiro.Application.Users.Commands.RegistrarUsuario;
using ControleFinanceiro.Application.Users.Commands.LoginUsuario;
using FluentValidation;
using MediatR;

namespace ControleFinanceiro.API.Extensions;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        // Registra todos os Handlers do assembly Application
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(RegistrarUsuarioHandler).Assembly));

        // Pipeline: valida antes de chegar no Handler
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Validators dos Commands de usuário
        services.AddScoped<IValidator<RegistrarUsuarioCommand>, RegistrarUsuarioCommandValidator>();
        services.AddScoped<IValidator<LoginUsuarioCommand>, LoginUsuarioCommandValidator>();

        return services;
    }
}
