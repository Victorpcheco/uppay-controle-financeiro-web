using ControleFinanceiro.Application.Dtos;
using MediatR;

namespace ControleFinanceiro.Application.Users.Commands.RegistrarUsuario;

/// <summary>
/// Command para registrar um novo usuário.
/// Implementa IRequest para retornar o token após o registro.
/// </summary>
public sealed record RegistrarUsuarioCommand(
    string NomeCompleto,
    string Email,
    string Senha) : IRequest<TokenResponseDto>;
