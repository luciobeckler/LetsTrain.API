using LetsTrain.API.DTO.Exercicio;
using LetsTrain.API.Services.Exercicios;
using Microsoft.AspNetCore.Mvc;

namespace LetsTrain.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciciosController : ControllerBase
    {
        private readonly IExerciciosService _exerciciosService;

        public ExerciciosController(IExerciciosService exerciciosService)
        {
            _exerciciosService = exerciciosService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercicio([FromBody] CreateExercicioDTO createExercicioDto)
        {
            var exercicio = await _exerciciosService.CreateExercicio(createExercicioDto);
            return CreatedAtAction(nameof(CreateExercicio), new { id = exercicio.Id }, exercicio);
        }
    }
}
