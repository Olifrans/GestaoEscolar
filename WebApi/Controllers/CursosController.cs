using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.InterfacesServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoDto>>> GetCursos()
        {
            var cursos = await _cursoService.GetAllAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDto>> GetCurso(int id)
        {
            var curso = await _cursoService.GetByIdAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<CursoDto>> CreateCurso(CursoDto cursoDto)
        {
            var createdCurso = await _cursoService.CreateAsync(cursoDto);
            return CreatedAtAction(nameof(GetCurso), new { id = createdCurso.Id }, createdCurso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurso(int id, CursoDto cursoDto)
        {
            if (id != cursoDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _cursoService.UpdateAsync(id, cursoDto);
            }
            catch (Exception)
            {
                if (await _cursoService.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _cursoService.GetByIdAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            await _cursoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
