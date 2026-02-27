using ControleFinanceiro.Domain.Events;

namespace ControleFinanceiro.Domain.Entities;

/// <summary>
/// Base para agregados que podem disparar domain events.
/// </summary>
public abstract class AggregateRoot : EntidadeBase
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();
}
