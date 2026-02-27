using ControleFinanceiro.Application.Mappers;

namespace ControleFinanceiro.API.Extensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(ContaBancariaMapper),
            typeof(CategoriaMapper),
            typeof(CartaoMapper),
            typeof(MesReferenciaMapper),
            typeof(MovimentacoesMapper)
        );

        return services;
    }
}
