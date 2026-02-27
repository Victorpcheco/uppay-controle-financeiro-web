namespace ControleFinanceiro.Domain.Exceptions;

/// <summary>
/// Exceção única para todas as regras de negócio violadas no domínio.
/// Use o <see cref="Codigo"/> para tratamento programático quando necessário.
/// </summary>
public class DomainException : Exception
{
    public DomainErrorCode Codigo { get; }

    public DomainException(string mensagem, DomainErrorCode codigo = DomainErrorCode.RegraDeNegocio)
        : base(mensagem)
    {
        Codigo = codigo;
    }
}

public enum DomainErrorCode
{
    RegraDeNegocio,
    NaoEncontrado,
    Conflito,
}
