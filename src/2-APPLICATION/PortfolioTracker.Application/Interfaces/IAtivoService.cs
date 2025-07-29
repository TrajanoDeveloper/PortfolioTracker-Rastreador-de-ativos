using PortfolioTracker.Application.DTOs;

namespace PortfolioTracker.Application.Interfaces
{
    public interface IAtivoService
    {
        Task<IEnumerable<AtivoDto>> GetAllAtivosAsync();
        Task<AtivoDto?> GetAtivoByIdAsync(int id);
        Task<AtivoDto?> GetAtivoByTickerAsync(string ticker);
        Task<AtivoDto> CreateAtivoAsync(CreateAtivoDto createAtivoDto);
        Task<AtivoDto?> UpdateAtivoAsync(int id, UpdateAtivoDto updateAtivoDto);
        Task<bool> DeleteAtivoAsync(int id);
        Task<bool> AtivoExistsAsync(int id);
        Task<bool> TickerExistsAsync(string ticker);
        Task UpdateCotacaoAsync(string ticker, decimal preco);
    }
}

