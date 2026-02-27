using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces;
using FluentValidation;

namespace ControleFinanceiro.Application.UseCases.Usuarios.LoginUsuario;

public class LoginUsuarioUseCase(
    IValidator<LoginRequestDto> loginValidator,
    IUsuarioRepository repository,
    IGerarToken token,
    IGerarRefreshToken refreshToken,
    IPasswordHasher passwordHasher) : ILoginUsuarioUseCase
{
    private const int RefreshTokenExpirationDays = 1;

    public async Task<TokenResponseDto> ExecuteAsync(LoginRequestDto requestDto)
    {
        var resultValidation = await loginValidator.ValidateAsync(requestDto);
        if (!resultValidation.IsValid)
            throw new ValidationException(resultValidation.Errors);

        var usuario = await repository.BuscarUsuarioPorEmailAsync(requestDto.Email);
        if (usuario == null)
            throw new DomainException($"Usuário com e-mail '{requestDto.Email}' não encontrado.", DomainErrorCode.NaoEncontrado);

        if (!usuario.VerificarSenha(requestDto.SenhaHash, passwordHasher))
            throw new DomainException("Senha incorreta.");

        var jwtToken = token.GeraToken(usuario);
        var refresh = refreshToken.GeraRefreshToken();
        var expiration = DateTime.Now.AddDays(RefreshTokenExpirationDays);

        await repository.AtualizarRefreshTokenAsync(usuario, refresh, expiration);
        return new TokenResponseDto() { Token = jwtToken, RefreshToken = refresh };
    }
}