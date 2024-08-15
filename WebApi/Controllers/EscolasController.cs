using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.InterfacesServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolasController : ControllerBase
    {
        private readonly IEscolaService _escolaService;

        public EscolasController(IEscolaService escolaService)
        {
            _escolaService = escolaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EscolaDto>>> GetEscolas()
        {
            var escolas = await _escolaService.GetAllAsync();
            return Ok(escolas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EscolaDto>> GetEscola(int id)
        {
            var escola = await _escolaService.GetByIdAsync(id);
            if (escola == null)
            {
                return NotFound();
            }
            return Ok(escola);
        }

        [HttpPost]
        public async Task<ActionResult<EscolaDto>> CreateEscola(EscolaDto escolaDto)
        {
            var createdEscola = await _escolaService.CreateAsync(escolaDto);
            return CreatedAtAction(nameof(GetEscola), new { id = createdEscola.Id }, createdEscola);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEscola(int id, EscolaDto escolaDto)
        {
            if (id != escolaDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _escolaService.UpdateAsync(id, escolaDto);
            }
            catch (Exception)
            {
                if (await _escolaService.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEscola(int id)
        {
            var escola = await _escolaService.GetByIdAsync(id);
            if (escola == null)
            {
                return NotFound();
            }

            await _escolaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
