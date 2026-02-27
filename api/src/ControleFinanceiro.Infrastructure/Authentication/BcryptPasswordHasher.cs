using ControleFinanceiro.Domain.Interfaces;

namespace ControleFinanceiro.Infrastructure.Authentication;

/// <summary>
/// Implementação concreta de IPasswordHasher usando BCrypt.
/// Fica na Infrastructure para não poluir o domínio com dependências externas.
/// </summary>
public class BcryptPasswordHasher : IPasswordHasher
{
    public string Hash(string senha) => BCrypt.Net.BCrypt.HashPassword(senha);

    public bool Verificar(string senha, string hash) => BCrypt.Net.BCrypt.Verify(senha, hash);
}
