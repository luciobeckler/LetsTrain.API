using LetsTrain.API.DTO.Treino;
using LetsTrain.API.Services.Treinos;
using Microsoft.AspNetCore.Mvc;

namespace LetsTrain.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinosController : ControllerBase
    {
        private readonly ITreinosService _treinosService;

        public TreinosController(ITreinosService treinosService)
        {
            _treinosService = treinosService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTreino([FromBody] CreateTreinoDTO createTreinoDto)
        {
            var treino = await _treinosService.CreateTreino(createTreinoDto);
            return CreatedAtAction(nameof(CreateTreino), new { id = treino.Id }, treino);
        }
    }
}
