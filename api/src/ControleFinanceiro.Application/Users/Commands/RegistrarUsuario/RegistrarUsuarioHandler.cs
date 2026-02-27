using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces;
using MediatR;

namespace ControleFinanceiro.Application.Users.Commands.RegistrarUsuario;

public sealed class RegistrarUsuarioHandler(
    IUsuarioRepository repository,
    IGerarRefreshToken gerarRefreshToken,
    IGerarToken gerarToken,
    IPasswordHasher passwordHasher) : IRequestHandler<RegistrarUsuarioCommand, TokenResponseDto>
{
    private const int RefreshTokenExpirationDays = 1;

    public async Task<TokenResponseDto> Handle(RegistrarUsuarioCommand command, CancellationToken cancellationToken)
    {
        var usuarioExiste = await repository.BuscarUsuarioPorEmailAsync(command.Email);
        if (usuarioExiste != null)
            throw new DomainException(
                $"Já existe um usuário cadastrado com o e-mail '{command.Email}'.",
                DomainErrorCode.Conflito);

        var refresh = gerarRefreshToken.GeraRefreshToken();
        var expiration = DateTime.Now.AddDays(RefreshTokenExpirationDays);

        var usuario = new Usuario(command.NomeCompleto, command.Email, command.Senha, refresh, expiration, passwordHasher);

        await repository.CriarUsuarioAsync(usuario);

        var jwtToken = gerarToken.GeraToken(usuario);

        return new TokenResponseDto { Token = jwtToken, RefreshToken = refresh };
    }
}
