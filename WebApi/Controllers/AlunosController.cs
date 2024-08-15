using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.InterfacesServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDto>>> GetAlunos()
        {
            var alunos = await _alunoService.GetAllAsync();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDto>> GetAluno(int id)
        {
            var aluno = await _alunoService.GetByIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<AlunoDto>> CreateAluno(AlunoDto alunoDto)
        {
            var createdAluno = await _alunoService.CreateAsync(alunoDto);
            return CreatedAtAction(nameof(GetAluno), new { id = createdAluno.Id }, createdAluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, AlunoDto alunoDto)
        {
            if (id != alunoDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _alunoService.UpdateAsync(id, alunoDto);
            }
            catch (Exception)
            {
                if (await _alunoService.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _alunoService.GetByIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            await _alunoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
