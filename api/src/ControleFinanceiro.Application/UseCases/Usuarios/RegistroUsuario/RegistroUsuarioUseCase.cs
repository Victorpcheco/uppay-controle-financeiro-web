using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces;
using FluentValidation;

namespace ControleFinanceiro.Application.UseCases.Usuarios.RegistroUsuario;

public class RegistroUsuarioUseCase(
    IUsuarioRepository repository,
    IValidator<RegisterRequestDto> registerValidator,
    IGerarRefreshToken refreshToken,
    IGerarToken token,
    IPasswordHasher passwordHasher) : IRegistroUsuarioUseCase
{
    private const int RefreshTokenExpirationDays = 1;

    public async Task<TokenResponseDto> ExecuteAsync(RegisterRequestDto requestDto)
    {
        var resultValidation = await registerValidator.ValidateAsync(requestDto);
        if (!resultValidation.IsValid)
            throw new ValidationException(resultValidation.Errors);

        var usuarioExiste = await repository.BuscarUsuarioPorEmailAsync(requestDto.Email);
        if (usuarioExiste != null)
            throw new DomainException($"Já existe um usuário cadastrado com o e-mail '{requestDto.Email}'.", DomainErrorCode.Conflito);

        var refresh = refreshToken.GeraRefreshToken();
        var expiration = DateTime.Now.AddDays(RefreshTokenExpirationDays);

        var usuario = new Usuario(requestDto.NomeCompleto, requestDto.Email, requestDto.SenhaHash, refresh, expiration, passwordHasher);
        await repository.CriarUsuarioAsync(usuario);

        var jwtToken = token.GeraToken(usuario);

        return new TokenResponseDto() { Token = jwtToken, RefreshToken = refresh };
    }
}