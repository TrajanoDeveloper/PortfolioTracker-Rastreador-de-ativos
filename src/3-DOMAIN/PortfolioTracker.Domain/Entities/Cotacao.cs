using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioTracker.Domain.Entities
{
    public class Cotacao
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoAbertura { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoFechamento { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoMaximo { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoMinimo { get; set; }
        
        [Column(TypeName = "decimal(18,0)")]
        public decimal Volume { get; set; }
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal Variacao { get; set; }
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal VariacaoPercentual { get; set; }
        
        public DateTime DataCotacao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        
        // Foreign Keys
        public int AtivoId { get; set; }
        
        // Navigation Properties
        public virtual Ativo Ativo { get; set; } = null!;
    }
}

