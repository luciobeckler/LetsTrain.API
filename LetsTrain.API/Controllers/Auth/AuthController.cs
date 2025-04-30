using LetsTrain.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LetsTrain.API.Controllers.Auth
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("role")]
        public IActionResult GetUserRole()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (role == null)
            {
                return Unauthorized("Role não encontrada.");
            }

            return Ok(new { role });
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserId([FromServices] LetsTrainDb context)
        {
            var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (identityUserId == null)
            {
                return Unauthorized("Id do usuário não encontrado no token.");
            }

            var aluno = await context.Alunos.FirstOrDefaultAsync(a => a.UserId == identityUserId);

            if (aluno == null)
            {
                return NotFound("Usuário não encontrado na tabela Alunos.");
            }

            return Ok(new { id = aluno.Id }); 
        }

    }
}
