using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.UseCases.Despesas.AtualizarDespesa;
using ControleFinanceiro.Application.UseCases.Despesas.BuscarDespesa;
using ControleFinanceiro.Application.UseCases.Despesas.CriarDespesa;
using ControleFinanceiro.Application.UseCases.Despesas.DeletarDespesa;
using ControleFinanceiro.Application.UseCases.Despesas.ListarDespesa;
using ControleFinanceiro.Application.UseCases.Despesas.ListarDespesaPorCartao;
using ControleFinanceiro.Application.UseCases.Despesas.ListarDespesaPorCategoria;
using ControleFinanceiro.Application.UseCases.Despesas.ListarDespesaPorContaBancaria;
using ControleFinanceiro.Application.UseCases.Despesas.ListarDespesaPorData;
using ControleFinanceiro.Application.UseCases.Despesas.ListarDespesaPorTitulo;
using ControleFinanceiro.Application.UseCases.Despesas.ListarMovimentacoesReceitas;
using ControleFinanceiro.Application.UseCases.Movimentacoess.ListarMovimentacoesPorCategoria;
using ControleFinanceiro.Application.Validators;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Repositories;
using FluentValidation;

namespace ControleFinanceiro.API.Extensions;

public static class MovimentacaoExtensions
{
    public static IServiceCollection AddMovimentacaoServices(this IServiceCollection services)
    {
        services.AddScoped<IMovimentacoesRepository, MovimentacoesRepository>();
        services.AddScoped<IListarMovimentacoesReceitasUseCase, ListarMovimentacoesReceitasUseCase>();
        services.AddScoped<IListarMovimentacoesUseCase, ListarMovimentacoesUseCase>();
        services.AddScoped<IValidator<MovimentacaoCriarDto>, MovimentacaoCriarDtoValidtor>();
        services.AddScoped<ICriarMovimentacaoUseCase, CriarMovimentacaoUseCase>();
        services.AddScoped<IAtualizarMovimentacaoUseCase, AtualizarMovimentacaoUseCase>();
        services.AddScoped<IBuscarMovimentacaoUseCase, BuscarMovimentacaoUseCase>();
        services.AddScoped<IDeletarMovimentacaoUseCase, DeletarMovimentacaoUseCase>();
        services.AddScoped<IListarMovimentacoesPorDataUseCase, ListarMovimentacoesPorDataUseCase>();
        services.AddScoped<IListarMovimentacoesPorContaBancariaUseCase, ListarMovimentacoesPorContaBancariaUseCase>();
        services.AddScoped<IListarMovimentacoesPorCategoriaUseCase, ListarMovimentacoesPorCategoriaUseCase>();
        services.AddScoped<IListarMovimentacoesPorTituloUseCase, ListarMovimentacoesPorTituloUseCase>();
        services.AddScoped<IListarMovimentacoesPorCartaoUseCase, ListarMovimentacoesPorCartaoUseCase>();

        return services;
    }
}
