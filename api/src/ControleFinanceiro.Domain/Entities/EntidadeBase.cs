namespace ControleFinanceiro.Domain.Entities;

public abstract class EntidadeBase
{
    public int Id { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public DateTime? AtualizadoEm { get; private set; }
    public bool Ativo { get; private set; } = true;

    protected EntidadeBase()
    {
        CriadoEm = DateTime.UtcNow;
    }

    public void DefinirCriadoEm(DateTime dataCriacao)
    {
        CriadoEm = dataCriacao;
    }

    public void DefinirAtualizadoEm(DateTime dataAtualizacao)
    {
        AtualizadoEm = dataAtualizacao;
    }

    public void Desativar()
    {
        Ativo = false;
        AtualizadoEm = DateTime.UtcNow;
    }

    public void Ativar()
    {
        Ativo = true;
        AtualizadoEm = DateTime.UtcNow;
    }
}
