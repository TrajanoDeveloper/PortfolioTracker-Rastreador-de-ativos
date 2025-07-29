using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PortfolioTracker.Domain.Enums;

namespace PortfolioTracker.Domain.Entities
{
    public class Operacao
    {
        [Key]
        public int Id { get; set; }
        
        public TipoOperacao Tipo { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Quantidade { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Custos { get; set; } = 0;
        
        public DateTime DataOperacao { get; set; }
        
        [StringLength(500)]
        public string? Observacoes { get; set; }
        
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        
        // Foreign Keys
        public int CarteiraId { get; set; }
        public int AtivoId { get; set; }
        
        // Navigation Properties
        public virtual Carteira Carteira { get; set; } = null!;
        public virtual Ativo Ativo { get; set; } = null!;
    }
}

