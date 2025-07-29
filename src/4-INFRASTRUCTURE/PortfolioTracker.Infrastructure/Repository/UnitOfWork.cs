using Microsoft.EntityFrameworkCore.Storage;
using PortfolioTracker.Domain.Entities;
using PortfolioTracker.Domain.Interfaces;
using PortfolioTracker.Infrastructure.Data;

namespace PortfolioTracker.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortfolioTrackerContext _context;
        private IDbContextTransaction? _transaction;

        private IRepository<Usuario>? _usuarios;
        private IRepository<Carteira>? _carteiras;
        private IRepository<Ativo>? _ativos;
        private IRepository<Posicao>? _posicoes;
        private IRepository<Operacao>? _operacoes;
        private IRepository<Cotacao>? _cotacoes;

        public UnitOfWork(PortfolioTrackerContext context)
        {
            _context = context;
        }

        public IRepository<Usuario> Usuarios => _usuarios ??= new Repository<Usuario>(_context);
        public IRepository<Carteira> Carteiras => _carteiras ??= new Repository<Carteira>(_context);
        public IRepository<Ativo> Ativos => _ativos ??= new Repository<Ativo>(_context);
        public IRepository<Posicao> Posicoes => _posicoes ??= new Repository<Posicao>(_context);
        public IRepository<Operacao> Operacoes => _operacoes ??= new Repository<Operacao>(_context);
        public IRepository<Cotacao> Cotacoes => _cotacoes ??= new Repository<Cotacao>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}

