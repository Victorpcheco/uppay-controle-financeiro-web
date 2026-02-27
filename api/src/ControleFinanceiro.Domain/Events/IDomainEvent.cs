namespace ControleFinanceiro.Domain.Events;

/// <summary>
/// Marcador para todos os domain events do sistema.
/// </summary>
public interface IDomainEvent
{
    DateTime OcorridoEm { get; }
}
