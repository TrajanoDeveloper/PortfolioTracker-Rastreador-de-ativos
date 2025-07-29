using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioTracker.Domain.Entities
{
    public class Carteira
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Descricao { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ObjetivoValor { get; set; }
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal ObjetivoPercentual { get; set; }
        
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public bool Ativa { get; set; } = true;
        
        // Foreign Keys
        public int UsuarioId { get; set; }
        
        // Navigation Properties
        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<Posicao> Posicoes { get; set; } = new List<Posicao>();
        public virtual ICollection<Operacao> Operacoes { get; set; } = new List<Operacao>();
    }
}

