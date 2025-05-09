﻿using LetsTrain.API.Data;
using LetsTrain.API.DTO.Account;
using LetsTrain.API.Models;
using LetsTrain.API.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LetsTrainDb _context;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AccountsController(UserManager<ApplicationUser> userManager, LetsTrainDb context, JwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAluno([FromBody] RegisterAlunoDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailEmUso = await _userManager.FindByEmailAsync(model.Email);
            if (emailEmUso != null)
                return BadRequest("E-mail já está em uso.");

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Senha);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Aluno");

            var aluno = new Aluno
            {
                Nome = model.Nome,
                Email = model.Email,
                IsAtivo = true,
                UserId = user.Id
            };

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Aluno registrado com sucesso" });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Senha))
                return Unauthorized("Usuário ou senha inválidos");

            var token = await _jwtTokenGenerator.GenerateToken(user);

            Response.Cookies.Append("auth_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, 
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddHours(1)
            });

            return Ok(new { message = "Login realizado com sucesso." });
        }
    }
}
