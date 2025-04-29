using Microsoft.AspNetCore.Mvc;
using LetsTrain.API.Services.Aulas;
using LetsTrain.API.DTO.Aula;
using LetsTrain.API.Models;

namespace LetsTrain.API.Controllers.Aulas
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private readonly IAulasService _aulasService;

        public AulasController(IAulasService aulasService)
        {
            _aulasService = aulasService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var aulas = await _aulasService.ListAllAsync();
            return Ok(aulas);
        }

        [HttpPost("{aulaId}/matricular/{alunoId}")]
        public async Task<IActionResult> MatricularAluno(int aulaId, int alunoId)
        {
            try
            {
                await _aulasService.MatricularAlunoNaAulaAsync(alunoId, aulaId);
                return Ok("Aluno matriculado com sucesso!");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao matricular aluno");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAula([FromBody] CreateAulaDTO createAulaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var aula = await _aulasService.CreateAulaAsync(createAulaDto);
            return CreatedAtAction(nameof(CreateAula), new { id = aula.Id }, aula);
        }

        [HttpGet("getDetalhesAulas/{id}")]
        public async Task<IActionResult> GetDetalhesAula(int id)
        {
            try
            {
                var detalhes = await _aulasService.GetDetalhesAulaByIdAsync(id);
                return Ok(detalhes);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno no servidor.", detalhes = ex.Message });
            }
        }
    }
}
