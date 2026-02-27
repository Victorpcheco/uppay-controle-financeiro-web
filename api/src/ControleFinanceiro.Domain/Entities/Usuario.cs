using ControleFinanceiro.Domain.Events;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Domain.ValueObjects;

namespace ControleFinanceiro.Domain.Entities;

public class Usuario : AggregateRoot
{
    // Propriedades expostas como string para compatibilidade com EF Core e queries existentes
    public string NomeCompleto { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string SenhaHash { get; private set; } = null!;
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiracao { get; private set; }

    public ICollection<Categoria> Categorias { get; set; } = null!;
    public ICollection<ContaBancaria> ContasBancarias { get; set; } = null!;
    public ICollection<Cartao> Cartoes { get; set; } = null!;
    public ICollection<Movimentacoes> Movimentacoes { get; set; } = null!;
    public ICollection<MesReferencia> MesesReferencia { get; set; } = null!;
    public ICollection<PlanejamentoCategoria> PlanejamentosCategorias { get; set; } = null!;

    // Construtor sem parâmetros para o EF Core
    protected Usuario() { }

    /// <summary>
    /// Cria um novo usuário validando todas as regras de domínio e disparando o evento de registro.
    /// </summary>
    public Usuario(string nomeCompleto, string email, string senhaPura, string refreshToken, DateTime expiration, IPasswordHasher hasher)
    {
        // Value Objects aplicam as regras e lançam DomainExceptions
        var nome = new NomeCompleto(nomeCompleto);
        var emailVo = new Email(email);
        var senhaVo = new Senha(senhaPura, hasher);

        NomeCompleto = nome;
        Email = emailVo;
        SenhaHash = senhaVo.Hash;
        RefreshToken = refreshToken;
        RefreshTokenExpiracao = expiration;

        RaiseDomainEvent(new UsuarioRegistradoEvent(Id, Email, NomeCompleto, DateTime.UtcNow));
    }

    /// <summary>
    /// Verifica se a senha fornecida confere com o hash armazenado.
    /// </summary>
    public bool VerificarSenha(string senhaPura, IPasswordHasher hasher) =>
        Senha.FromHash(SenhaHash).Verificar(senhaPura, hasher);

    /// <summary>
    /// Atualiza o refresh token do usuário.
    /// </summary>
    public void AtualizarRefreshToken(string refreshToken, DateTime expiracao)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiracao = expiracao;
    }
}