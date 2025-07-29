using PortfolioTracker.Domain.Enums;

namespace PortfolioTracker.Application.DTOs
{
    public class OperacaoDto
    {
        public int Id { get; set; }
        public TipoOperacao Tipo { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Custos { get; set; }
        public DateTime DataOperacao { get; set; }
        public string? Observacoes { get; set; }
        public int CarteiraId { get; set; }
        public int AtivoId { get; set; }
        public string AtivoTicker { get; set; } = string.Empty;
        public string AtivoNome { get; set; } = string.Empty;
    }

    public class CreateOperacaoDto
    {
        public TipoOperacao Tipo { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Custos { get; set; } = 0;
        public DateTime DataOperacao { get; set; }
        public string? Observacoes { get; set; }
        public int CarteiraId { get; set; }
        public int AtivoId { get; set; }
    }

    public class UpdateOperacaoDto
    {
        public TipoOperacao Tipo { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Custos { get; set; }
        public DateTime DataOperacao { get; set; }
        public string? Observacoes { get; set; }
    }
}

