using System.ComponentModel.DataAnnotations;

namespace PortfolioTracker.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        
        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string SenhaHash { get; set; } = string.Empty;
        
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataUltimoLogin { get; set; }
        public bool Ativo { get; set; } = true;
        
        // Navigation Properties
        public virtual ICollection<Carteira> Carteiras { get; set; } = new List<Carteira>();
    }
}

