using PortfolioTracker.Domain.Enums;

namespace PortfolioTracker.Application.DTOs
{
    public class AtivoDto
    {
        public int Id { get; set; }
        public string Ticker { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public TipoAtivo Tipo { get; set; }
        public string? Setor { get; set; }
        public string? Segmento { get; set; }
        public decimal? PrecoAtual { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        public bool IsAtivo { get; set; }
    }

    public class CreateAtivoDto
    {
        public string Ticker { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public TipoAtivo Tipo { get; set; }
        public string? Setor { get; set; }
        public string? Segmento { get; set; }
    }

    public class UpdateAtivoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public TipoAtivo Tipo { get; set; }
        public string? Setor { get; set; }
        public string? Segmento { get; set; }
        public bool IsAtivo { get; set; }
    }
}

