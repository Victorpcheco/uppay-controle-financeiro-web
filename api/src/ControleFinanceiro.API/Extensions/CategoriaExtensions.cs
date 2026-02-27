using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.UseCases.Categorias.AtualizarCategoria;
using ControleFinanceiro.Application.UseCases.Categorias.BuscarCategoria;
using ControleFinanceiro.Application.UseCases.Categorias.CriarCategoria;
using ControleFinanceiro.Application.UseCases.Categorias.DeletarCategoria;
using ControleFinanceiro.Application.UseCases.Categorias.ListarCategorias;
using ControleFinanceiro.Application.Validators;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infrastructure.Repositories;
using FluentValidation;

namespace ControleFinanceiro.API.Extensions;

public static class CategoriaExtensions
{
    public static IServiceCollection AddCategoriaServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IListarCategoriasUseCase, ListarCategoriasUseCase>();
        services.AddScoped<IBuscarCategoriaUseCase, BuscarCategoriaUseCase>();
        services.AddScoped<ICriarCategoriaUseCase, CriarCategoriaUseCase>();
        services.AddScoped<IAtualizarCategoriaUseCase, AtualizarCategoriaUseCase>();
        services.AddScoped<IDeletarCategoriaUseCase, DeletarCategoriaUseCase>();
        services.AddScoped<IValidator<CategoriaCriarDto>, CategoriaRequestValidator>();

        return services;
    }
}
