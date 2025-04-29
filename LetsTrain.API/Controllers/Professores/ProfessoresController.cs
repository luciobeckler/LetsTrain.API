using LetsTrain.API.DTO.Professor;
using LetsTrain.API.Services.Professores;
using Microsoft.AspNetCore.Mvc;

namespace LetsTrain.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessoresService _professoresService;

        public ProfessoresController(IProfessoresService professoresService)
        {
            _professoresService = professoresService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessor([FromBody] CreateProfessorDTO createProfessorDto)
        {
            var professor = await _professoresService.CreateProfessor(createProfessorDto);
            return CreatedAtAction(nameof(CreateProfessor), new { id = professor.Id }, professor);
        }
    }
}
