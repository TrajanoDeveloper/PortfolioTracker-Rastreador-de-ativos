using Microsoft.AspNetCore.Mvc;
using PortfolioTracker.Application.DTOs;
using PortfolioTracker.Application.Interfaces;

namespace PortfolioTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtivosController : ControllerBase
    {
        private readonly IAtivoService _ativoService;

        public AtivosController(IAtivoService ativoService)
        {
            _ativoService = ativoService;
        }

        /// <summary>
        /// Obtém todos os ativos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtivoDto>>> GetAtivos()
        {
            var ativos = await _ativoService.GetAllAtivosAsync();
            return Ok(ativos);
        }

        /// <summary>
        /// Obtém um ativo por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AtivoDto>> GetAtivo(int id)
        {
            var ativo = await _ativoService.GetAtivoByIdAsync(id);
            if (ativo == null)
                return NotFound($"Ativo com ID {id} não encontrado.");

            return Ok(ativo);
        }

        /// <summary>
        /// Obtém um ativo por ticker
        /// </summary>
        [HttpGet("ticker/{ticker}")]
        public async Task<ActionResult<AtivoDto>> GetAtivoByTicker(string ticker)
        {
            var ativo = await _ativoService.GetAtivoByTickerAsync(ticker);
            if (ativo == null)
                return NotFound($"Ativo com ticker {ticker} não encontrado.");

            return Ok(ativo);
        }

        /// <summary>
        /// Cria um novo ativo
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AtivoDto>> CreateAtivo(CreateAtivoDto createAtivoDto)
        {
            if (await _ativoService.TickerExistsAsync(createAtivoDto.Ticker))
                return BadRequest($"Já existe um ativo com o ticker {createAtivoDto.Ticker}.");

            var ativo = await _ativoService.CreateAtivoAsync(createAtivoDto);
            return CreatedAtAction(nameof(GetAtivo), new { id = ativo.Id }, ativo);
        }

        /// <summary>
        /// Atualiza um ativo existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<AtivoDto>> UpdateAtivo(int id, UpdateAtivoDto updateAtivoDto)
        {
            var ativo = await _ativoService.UpdateAtivoAsync(id, updateAtivoDto);
            if (ativo == null)
                return NotFound($"Ativo com ID {id} não encontrado.");

            return Ok(ativo);
        }

        /// <summary>
        /// Remove um ativo
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtivo(int id)
        {
            var success = await _ativoService.DeleteAtivoAsync(id);
            if (!success)
                return NotFound($"Ativo com ID {id} não encontrado.");

            return NoContent();
        }

        /// <summary>
        /// Atualiza a cotação de um ativo
        /// </summary>
        [HttpPatch("{ticker}/cotacao")]
        public async Task<IActionResult> UpdateCotacao(string ticker, [FromBody] decimal preco)
        {
            if (preco <= 0)
                return BadRequest("O preço deve ser maior que zero.");

            await _ativoService.UpdateCotacaoAsync(ticker, preco);
            return NoContent();
        }
    }
}

