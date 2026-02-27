using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.UseCases.Cartoes.AtualizarCartao;
using ControleFinanceiro.Application.UseCases.Cartoes.BuscarCartao;
using ControleFinanceiro.Application.UseCases.Cartoes.CriarCartao;
using ControleFinanceiro.Application.UseCases.Cartoes.DeletarCartao;
using ControleFinanceiro.Application.UseCases.Cartoes.ListarCartao;
using ControleFinanceiro.Application.Validators;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Repositories;
using FluentValidation;

namespace ControleFinanceiro.API.Extensions;

public static class CartaoExtensions
{
    public static IServiceCollection AddCartaoServices(this IServiceCollection services)
    {
        services.AddScoped<ICartaoRepository, CartaoRepository>();
        services.AddScoped<IListarCartaoPaginadoUseCase, ListarCartaoPaginadoUseCase>();
        services.AddScoped<IBuscarCartaoUseCase, BuscarCartaoUseCase>();
        services.AddScoped<ICriarCartaoUseCase, CriarCartaoUseCase>();
        services.AddScoped<IAtualizarCartaoUseCase, AtualizarCartaoUseCase>();
        services.AddScoped<IDeletarCartaoUseCase, DeletarCartaoUseCase>();
        services.AddScoped<IValidator<CartaoCriarDto>, CartaoCriarDtoValidator>();

        return services;
    }
}
