using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.InterfacesServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessoresController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorDto>>> GetProfessores()
        {
            var professores = await _professorService.GetAllAsync();
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorDto>> GetProfessor(int id)
        {
            var professor = await _professorService.GetByIdAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        [HttpPost]
        public async Task<ActionResult<ProfessorDto>> CreateProfessor(ProfessorDto professorDto)
        {
            var createdProfessor = await _professorService.CreateAsync(professorDto);
            return CreatedAtAction(nameof(GetProfessor), new { id = createdProfessor.Id }, createdProfessor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, ProfessorDto professorDto)
        {
            if (id != professorDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _professorService.UpdateAsync(id, professorDto);
            }
            catch (Exception)
            {
                if (await _professorService.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var professor = await _professorService.GetByIdAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            await _professorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
