using PortfolioTracker.Application.DTOs;

namespace PortfolioTracker.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardConsolidadoAsync(int usuarioId);
        Task<IEnumerable<PosicaoResumoDto>> GetPosicoesResumoAsync(int carteiraId);
        Task<IEnumerable<RendimentoMensalDto>> GetRendimentosMensaisAsync(int carteiraId, int ano);
        Task<ReservaEmergenciaDto> GetReservaEmergenciaAsync(int usuarioId);
        Task<IEnumerable<ObjetivoAtivoDto>> GetObjetivosAtivosAsync(int carteiraId);
    }
}

