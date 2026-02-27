using ControleFinanceiro.Application.UseCases.Dashboard.ListarMovimentacoesEmAberto;
using ControleFinanceiro.Application.UseCases.Financeiro.ListarSaldosContas;
using ControleFinanceiro.Application.UseCases.Financeiro.ObterDespesasEmAberto;
using ControleFinanceiro.Application.UseCases.Financeiro.ObterReceitasEmAberto;
using ControleFinanceiro.Application.UseCases.Financeiro.ObterSaldoTotal;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Repositories;

namespace ControleFinanceiro.API.Extensions;

public static class DashboardExtensions
{
    public static IServiceCollection AddDashboardServices(this IServiceCollection services)
    {
        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IObterValorEmAbertoDespesasUseCase, ObterValorEmAbertoDespesasUseCase>();
        services.AddScoped<IObterValorEmAbertoReceitasUseCase, ObterValorEmAbertoReceitasUseCase>();
        services.AddScoped<IObterSaldoTotalUseCase, ObterSaldoTotalUseCase>();
        services.AddScoped<IListarContasComSaldoTotalUseCase, ListarContasComSaldoTotalUseCase>();
        services.AddScoped<IListarMovimentacoesEmAbertoUseCase, ListarMovimentacoesEmAbertoUseCase>();

        return services;
    }
}
