namespace ControleFinanceiro.Domain.Interfaces;

/// <summary>
/// Abstração de hashing de senhas. A implementação concreta fica na Infrastructure.
/// </summary>
public interface IPasswordHasher
{
    string Hash(string senha);
    bool Verificar(string senha, string hash);
}
