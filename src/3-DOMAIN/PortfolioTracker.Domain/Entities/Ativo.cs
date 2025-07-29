using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PortfolioTracker.Domain.Enums;

namespace PortfolioTracker.Domain.Entities
{
    public class Ativo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Ticker { get; set; } = string.Empty;
        
        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Descricao { get; set; }
        
        public TipoAtivo Tipo { get; set; }
        
        [StringLength(10)]
        public string? Setor { get; set; }
        
        [StringLength(100)]
        public string? Segmento { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PrecoAtual { get; set; }
        
        public DateTime? DataUltimaAtualizacao { get; set; }
        
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public bool IsAtivo { get; set; } = true;
        
        // Navigation Properties
        public virtual ICollection<Posicao> Posicoes { get; set; } = new List<Posicao>();
        public virtual ICollection<Operacao> Operacoes { get; set; } = new List<Operacao>();
        public virtual ICollection<Cotacao> Cotacoes { get; set; } = new List<Cotacao>();
    }
}

