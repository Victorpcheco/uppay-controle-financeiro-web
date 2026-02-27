using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.UseCases.Usuarios.LoginUsuario;
using ControleFinanceiro.Application.UseCases.Usuarios.RegistroUsuario;
using ControleFinanceiro.Application.Validators;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Repositories;
using FluentValidation;

namespace ControleFinanceiro.API.Extensions;

public static class UsuarioExtensions
{
    public static IServiceCollection AddUsuarioServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ILoginUsuarioUseCase, LoginUsuarioUseCase>();
        services.AddScoped<IRegistroUsuarioUseCase, RegistroUsuarioUseCase>();
        services.AddScoped<IValidator<LoginRequestDto>, LoginRequestDtoValidator>();
        services.AddScoped<IValidator<RegisterRequestDto>, RegisterRequestDtoValidator>();

        return services;
    }
}
