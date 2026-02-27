using System.Text.RegularExpressions;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces;

namespace ControleFinanceiro.Domain.ValueObjects;

/// <summary>
/// Value Object que encapsula a senha do usuário.
/// Recebe a senha em texto puro, valida as regras e delega o hash ao IPasswordHasher.
/// </summary>
public sealed class Senha
{
    private static readonly Regex RegexForte =
        new(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$", RegexOptions.Compiled);

    /// <summary>Hash gerado pelo IPasswordHasher.</summary>
    public string Hash { get; }

    /// <summary>
    /// Cria um novo Senha validando as regras e gerando o hash.
    /// </summary>
    public Senha(string senhaPura, IPasswordHasher hasher)
    {
        Validar(senhaPura);
        Hash = hasher.Hash(senhaPura);
    }

    /// <summary>
    /// Reconstitui o VO a partir de um hash já existente (uso do ORM / repositório).
    /// </summary>
    public static Senha FromHash(string hash) => new(hash);

    /// <summary>Verifica se a senha em texto puro confere com o hash armazenado.</summary>
    public bool Verificar(string senhaPura, IPasswordHasher hasher) =>
        hasher.Verificar(senhaPura, Hash);

    // Construtor privado para FromHash — não revalida nem re-hasheia.
    private Senha(string hashExistente)
    {
        Hash = hashExistente;
    }

    private static void Validar(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            throw new DomainException("Senha não pode ser vazia.");

        if (senha.Length < 6)
            throw new DomainException("Senha deve ter pelo menos 6 caracteres.");

        if (!RegexForte.IsMatch(senha))
            throw new DomainException(
                "Senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.");
    }
}
