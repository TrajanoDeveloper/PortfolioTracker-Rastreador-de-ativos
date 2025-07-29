using AutoMapper;
using PortfolioTracker.Application.DTOs;
using PortfolioTracker.Application.Interfaces;
using PortfolioTracker.Domain.Entities;
using PortfolioTracker.Domain.Interfaces;

namespace PortfolioTracker.Application.Services
{
    public class AtivoService : IAtivoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AtivoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AtivoDto>> GetAllAtivosAsync()
        {
            var ativos = await _unitOfWork.Ativos.GetAllAsync();
            return _mapper.Map<IEnumerable<AtivoDto>>(ativos);
        }

        public async Task<AtivoDto?> GetAtivoByIdAsync(int id)
        {
            var ativo = await _unitOfWork.Ativos.GetByIdAsync(id);
            return ativo != null ? _mapper.Map<AtivoDto>(ativo) : null;
        }

        public async Task<AtivoDto?> GetAtivoByTickerAsync(string ticker)
        {
            var ativo = await _unitOfWork.Ativos.FirstOrDefaultAsync(a => a.Ticker == ticker);
            return ativo != null ? _mapper.Map<AtivoDto>(ativo) : null;
        }

        public async Task<AtivoDto> CreateAtivoAsync(CreateAtivoDto createAtivoDto)
        {
            var ativo = _mapper.Map<Ativo>(createAtivoDto);
            await _unitOfWork.Ativos.AddAsync(ativo);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<AtivoDto>(ativo);
        }

        public async Task<AtivoDto?> UpdateAtivoAsync(int id, UpdateAtivoDto updateAtivoDto)
        {
            var ativo = await _unitOfWork.Ativos.GetByIdAsync(id);
            if (ativo == null) return null;

            _mapper.Map(updateAtivoDto, ativo);
            await _unitOfWork.Ativos.UpdateAsync(ativo);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<AtivoDto>(ativo);
        }

        public async Task<bool> DeleteAtivoAsync(int id)
        {
            var ativo = await _unitOfWork.Ativos.GetByIdAsync(id);
            if (ativo == null) return false;

            await _unitOfWork.Ativos.DeleteAsync(ativo);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AtivoExistsAsync(int id)
        {
            return await _unitOfWork.Ativos.ExistsAsync(id);
        }

        public async Task<bool> TickerExistsAsync(string ticker)
        {
            var ativo = await _unitOfWork.Ativos.FirstOrDefaultAsync(a => a.Ticker == ticker);
            return ativo != null;
        }

        public async Task UpdateCotacaoAsync(string ticker, decimal preco)
        {
            var ativo = await _unitOfWork.Ativos.FirstOrDefaultAsync(a => a.Ticker == ticker);
            if (ativo != null)
            {
                ativo.PrecoAtual = preco;
                ativo.DataUltimaAtualizacao = DateTime.UtcNow;
                await _unitOfWork.Ativos.UpdateAsync(ativo);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}

