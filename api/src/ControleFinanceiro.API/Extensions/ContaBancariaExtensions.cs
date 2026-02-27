using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.UseCases.Contas.AtualizarContaBancaria;
using ControleFinanceiro.Application.UseCases.Contas.BuscarContaBancaria;
using ControleFinanceiro.Application.UseCases.Contas.CriarContaBancaria;
using ControleFinanceiro.Application.UseCases.Contas.DeletarContaBancaria;
using ControleFinanceiro.Application.UseCases.Contas.ListarContaBancaria;
using ControleFinanceiro.Application.Validators;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Repositories;
using FluentValidation;

namespace ControleFinanceiro.API.Extensions;

public static class ContaBancariaExtensions
{
    public static IServiceCollection AddContaBancariaServices(this IServiceCollection services)
    {
        services.AddScoped<IContaBancariaRepository, ContaBancariaRepository>();
        services.AddScoped<IListarContasBancariasUseCase, ListarContasBancariasUseCase>();
        services.AddScoped<IBuscarContaBancariaUseCase, BuscarContaBancariaUseCase>();
        services.AddScoped<ICriarContaBancariaUseCase, CriarContaBancariaUseCase>();
        services.AddScoped<IAtualizarContaBancariaUseCase, AtualizarContaBancariaUseCaseUseCase>();
        services.AddScoped<IDeletarContaBancariaUseCase, DeletarContaBancariaUseCase>();
        services.AddScoped<IValidator<ContaBancariaCriarDto>, ContaBancariaCriarDtoValidator>();
        services.AddScoped<IValidator<ContaBancariaAtualizarDto>, ContaBancariaAtualizarDtoValidator>();

        return services;
    }
}
