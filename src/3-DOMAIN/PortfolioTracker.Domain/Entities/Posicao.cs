using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioTracker.Domain.Entities
{
    public class Posicao
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Quantidade { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoMedio { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorInvestido { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorAtual { get; set; }
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal PercentualCarteira { get; set; }
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal Variacao { get; set; }
        
        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.UtcNow;
        
        // Foreign Keys
        public int CarteiraId { get; set; }
        public int AtivoId { get; set; }
        
        // Navigation Properties
        public virtual Carteira Carteira { get; set; } = null!;
        public virtual Ativo Ativo { get; set; } = null!;
    }
}

