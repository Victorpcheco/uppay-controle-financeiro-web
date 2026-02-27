using ControleFinanceiro.Domain.Exceptions;

namespace ControleFinanceiro.Domain.ValueObjects;

/// <summary>
/// Value Object que encapsula o nome completo do usuário e suas regras.
/// </summary>
public sealed class NomeCompleto : IEquatable<NomeCompleto>
{
    private const int TamanhoMaximo = 100;

    public string Valor { get; }

    public NomeCompleto(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new DomainException("Nome completo não pode ser vazio.");

        if (valor.Length > TamanhoMaximo)
            throw new DomainException($"Nome completo não pode ter mais de {TamanhoMaximo} caracteres.");

        Valor = valor.Trim();
    }

    public override string ToString() => Valor;

    public bool Equals(NomeCompleto? other) =>
        other is not null && string.Equals(Valor, other.Valor, StringComparison.OrdinalIgnoreCase);

    public override bool Equals(object? obj) => obj is NomeCompleto n && Equals(n);
    public override int GetHashCode() => Valor.GetHashCode(StringComparison.OrdinalIgnoreCase);

    public static implicit operator string(NomeCompleto nome) => nome.Valor;
}
