using PortfolioTracker.Domain.Entities;

namespace PortfolioTracker.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Usuario> Usuarios { get; }
        IRepository<Carteira> Carteiras { get; }
        IRepository<Ativo> Ativos { get; }
        IRepository<Posicao> Posicoes { get; }
        IRepository<Operacao> Operacoes { get; }
        IRepository<Cotacao> Cotacoes { get; }
        
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}

