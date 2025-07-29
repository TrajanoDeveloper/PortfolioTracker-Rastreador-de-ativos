using PortfolioTracker.Application.DTOs;

namespace PortfolioTracker.Application.Interfaces
{
    public interface IOperacaoService
    {
        Task<IEnumerable<OperacaoDto>> GetAllOperacoesAsync();
        Task<IEnumerable<OperacaoDto>> GetOperacoesByCarteiraAsync(int carteiraId);
        Task<OperacaoDto?> GetOperacaoByIdAsync(int id);
        Task<OperacaoDto> CreateOperacaoAsync(CreateOperacaoDto createOperacaoDto);
        Task<OperacaoDto?> UpdateOperacaoAsync(int id, UpdateOperacaoDto updateOperacaoDto);
        Task<bool> DeleteOperacaoAsync(int id);
        Task<bool> OperacaoExistsAsync(int id);
    }
}

