using ControleFinanceiro.Application.Dtos;
using MediatR;

namespace ControleFinanceiro.Application.Users.Commands.LoginUsuario;

/// <summary>
/// Command para autenticar um usuário existente.
/// Login é um Command (não Query) pois tem side effect: grava o refresh token.
/// </summary>
public sealed record LoginUsuarioCommand(
    string Email,
    string Senha) : IRequest<TokenResponseDto>;
