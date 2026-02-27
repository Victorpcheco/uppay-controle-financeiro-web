using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.UseCases.MesDeReferencia.AtualizarMesReferencia;
using ControleFinanceiro.Application.UseCases.MesDeReferencia.BuscarMesReferencia;
using ControleFinanceiro.Application.UseCases.MesDeReferencia.CriarMesReferencia;
using ControleFinanceiro.Application.UseCases.MesDeReferencia.DeletarMesReferencia;
using ControleFinanceiro.Application.UseCases.MesDeReferencia.ListarMesReferencia;
using ControleFinanceiro.Application.Validators;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Repositories;
using FluentValidation;

namespace ControleFinanceiro.API.Extensions;

public static class MesReferenciaExtensions
{
    public static IServiceCollection AddMesReferenciaServices(this IServiceCollection services)
    {
        services.AddScoped<IMesReferenciaRepository, MesReferenciaRepository>();
        services.AddScoped<IAtualizarMesReferenciaUseCase, AtualizarMesReferenciaUseCase>();
        services.AddScoped<ICriarMesReferenciaUseCase, CriarMesReferenciaUseCase>();
        services.AddScoped<IDeletarMesReferenciaUseCase, DeletarMesReferenciaUseCase>();
        services.AddScoped<IBuscarMesReferenciaUseCase, BuscarMesReferenciaUseCase>();
        services.AddScoped<IListarMesReferenciaUseCase, ListarMesReferenciaUseCase>();
        services.AddScoped<IValidator<MesReferenciaCriarDto>, MesReferenciaCriarDtoValidator>();

        return services;
    }
}
