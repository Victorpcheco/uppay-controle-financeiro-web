namespace ControleFinanceiro.Domain.Events;

/// <summary>
/// Disparado quando um novo usuário é registrado no sistema.
/// </summary>
public sealed record UsuarioRegistradoEvent(
    int UsuarioId,
    string Email,
    string NomeCompleto,
    DateTime OcorridoEm) : IDomainEvent;
