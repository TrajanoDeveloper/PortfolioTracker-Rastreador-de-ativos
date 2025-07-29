using Microsoft.EntityFrameworkCore;
using PortfolioTracker.Domain.Entities;
using PortfolioTracker.Domain.Enums;

namespace PortfolioTracker.Infrastructure.Data
{
    public class PortfolioTrackerContext : DbContext
    {
        public PortfolioTrackerContext(DbContextOptions<PortfolioTrackerContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações de relacionamentos
            modelBuilder.Entity<Carteira>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Carteiras)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Posicao>()
                .HasOne(p => p.Carteira)
                .WithMany(c => c.Posicoes)
                .HasForeignKey(p => p.CarteiraId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Posicao>()
                .HasOne(p => p.Ativo)
                .WithMany(a => a.Posicoes)
                .HasForeignKey(p => p.AtivoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Operacao>()
                .HasOne(o => o.Carteira)
                .WithMany(c => c.Operacoes)
                .HasForeignKey(o => o.CarteiraId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Operacao>()
                .HasOne(o => o.Ativo)
                .WithMany(a => a.Operacoes)
                .HasForeignKey(o => o.AtivoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cotacao>()
                .HasOne(c => c.Ativo)
                .WithMany(a => a.Cotacoes)
                .HasForeignKey(c => c.AtivoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices únicos
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Ativo>()
                .HasIndex(a => a.Ticker)
                .IsUnique();

            modelBuilder.Entity<Posicao>()
                .HasIndex(p => new { p.CarteiraId, p.AtivoId })
                .IsUnique();

            modelBuilder.Entity<Cotacao>()
                .HasIndex(c => new { c.AtivoId, c.DataCotacao })
                .IsUnique();

            // Seed Data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Ativos
            modelBuilder.Entity<Ativo>().HasData(
                new Ativo { Id = 1, Ticker = "PETR4", Nome = "Petróleo Brasileiro S.A. - Petrobras", Tipo = TipoAtivo.Acao, Setor = "Energia", Segmento = "Petróleo e Gás", IsAtivo = true },
                new Ativo { Id = 2, Ticker = "VALE3", Nome = "Vale S.A.", Tipo = TipoAtivo.Acao, Setor = "Materiais Básicos", Segmento = "Mineração", IsAtivo = true },
                new Ativo { Id = 3, Ticker = "ITUB4", Nome = "Itaú Unibanco Holding S.A.", Tipo = TipoAtivo.Acao, Setor = "Financeiro", Segmento = "Bancos", IsAtivo = true },
                new Ativo { Id = 4, Ticker = "BBDC4", Nome = "Banco Bradesco S.A.", Tipo = TipoAtivo.Acao, Setor = "Financeiro", Segmento = "Bancos", IsAtivo = true },
                new Ativo { Id = 5, Ticker = "ABEV3", Nome = "Ambev S.A.", Tipo = TipoAtivo.Acao, Setor = "Consumo", Segmento = "Bebidas", IsAtivo = true },
                new Ativo { Id = 6, Ticker = "HGLG11", Nome = "CSHG Logística FII", Tipo = TipoAtivo.FII, Setor = "Logística", IsAtivo = true },
                new Ativo { Id = 7, Ticker = "XPML11", Nome = "XP Malls FII", Tipo = TipoAtivo.FII, Setor = "Shopping", IsAtivo = true },
                new Ativo { Id = 8, Ticker = "IVVB11", Nome = "iShares Core S&P 500", Tipo = TipoAtivo.ETF, Setor = "Internacional", IsAtivo = true },
                new Ativo { Id = 9, Ticker = "BOVA11", Nome = "iShares Ibovespa", Tipo = TipoAtivo.ETF, Setor = "Índice", IsAtivo = true },
                new Ativo { Id = 10, Ticker = "SELIC", Nome = "Tesouro Selic", Tipo = TipoAtivo.RendaFixa, Setor = "Governo", IsAtivo = true }
            );
        }
    }
}

