namespace PortfolioTracker.Application.DTOs
{
    public class DashboardDto
    {
        public decimal TotalAplicado { get; set; }
        public decimal TotalAtual { get; set; }
        public decimal Rentabilidade { get; set; }
        public decimal RentabilidadePercentual { get; set; }
        public int QuantidadeAtivos { get; set; }
        public decimal PrecoMedio { get; set; }
        public List<PosicaoResumoDto> Posicoes { get; set; } = new();
        public List<RendimentoMensalDto> RendimentosMensais { get; set; } = new();
        public ReservaEmergenciaDto ReservaEmergencia { get; set; } = new();
        public List<ObjetivoAtivoDto> ObjetivosAtivos { get; set; } = new();
    }

    public class PosicaoResumoDto
    {
        public string Ticker { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public decimal Quantidade { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorAtual { get; set; }
        public decimal PercentualCarteira { get; set; }
        public decimal Variacao { get; set; }
        public decimal VariacaoPercentual { get; set; }
    }

    public class RendimentoMensalDto
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string MesNome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }

    public class ReservaEmergenciaDto
    {
        public decimal ValorAtual { get; set; }
        public decimal ValorObjetivo { get; set; }
        public decimal PercentualAlcancado { get; set; }
    }

    public class ObjetivoAtivoDto
    {
        public string Ticker { get; set; } = string.Empty;
        public decimal PercentualObjetivo { get; set; }
        public decimal PercentualAtual { get; set; }
        public decimal DiferencaPercentual { get; set; }
    }
}

