using System.Net.Mail;
using ControleFinanceiro.Domain.Exceptions;

namespace ControleFinanceiro.Domain.ValueObjects;

/// <summary>
/// Value Object que garante que um endereço de e-mail é válido.
/// </summary>
public sealed class Email : IEquatable<Email>
{
    public string Valor { get; }

    public Email(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new DomainException("E-mail não pode ser vazio.");

        try
        {
            var addr = new MailAddress(valor);
            Valor = addr.Address.ToLowerInvariant();
        }
        catch
        {
            throw new DomainException($"O e-mail '{valor}' é inválido.");
        }
    }

    public override string ToString() => Valor;

    public bool Equals(Email? other) =>
        other is not null && string.Equals(Valor, other.Valor, StringComparison.OrdinalIgnoreCase);

    public override bool Equals(object? obj) => obj is Email e && Equals(e);
    public override int GetHashCode() => Valor.GetHashCode(StringComparison.OrdinalIgnoreCase);

    public static implicit operator string(Email email) => email.Valor;
}
