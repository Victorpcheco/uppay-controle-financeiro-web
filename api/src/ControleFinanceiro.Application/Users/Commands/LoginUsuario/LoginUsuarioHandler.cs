using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces;
using MediatR;

namespace ControleFinanceiro.Application.Users.Commands.LoginUsuario;

public sealed class LoginUsuarioHandler(
    IUsuarioRepository repository,
    IGerarToken gerarToken,
    IGerarRefreshToken gerarRefreshToken,
    IPasswordHasher passwordHasher) : IRequestHandler<LoginUsuarioCommand, TokenResponseDto>
{
    private const int RefreshTokenExpirationDays = 1;

    public async Task<TokenResponseDto> Handle(LoginUsuarioCommand command, CancellationToken cancellationToken)
    {
        var usuario = await repository.BuscarUsuarioPorEmailAsync(command.Email);
        if (usuario is null)
            throw new DomainException(
                $"Usuário com e-mail '{command.Email}' não encontrado.",
                DomainErrorCode.NaoEncontrado);

        if (!usuario.VerificarSenha(command.Senha, passwordHasher))
            throw new DomainException("Senha incorreta.");

        var refresh = gerarRefreshToken.GeraRefreshToken();
        var expiration = DateTime.Now.AddDays(RefreshTokenExpirationDays);

        await repository.AtualizarRefreshTokenAsync(usuario, refresh, expiration);

        var jwtToken = gerarToken.GeraToken(usuario);

        return new TokenResponseDto { Token = jwtToken, RefreshToken = refresh };
    }
}
