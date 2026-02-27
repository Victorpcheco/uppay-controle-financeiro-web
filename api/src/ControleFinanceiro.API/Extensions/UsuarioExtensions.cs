using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Repositories;

namespace ControleFinanceiro.API.Extensions;

public static class UsuarioExtensions
{
    public static IServiceCollection AddUsuarioServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}
