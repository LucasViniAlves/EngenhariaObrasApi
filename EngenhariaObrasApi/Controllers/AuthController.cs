using Microsoft.AspNetCore.Mvc;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EngenhariaObrasApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UsuarioRegisterDTO dto)
        {
            var token = await _usuarioService.RegistrarAsync(dto);
            if (token == null) return BadRequest("Email já cadastrado.");
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginDTO dto)
        {
            var token = await _usuarioService.LoginAsync(dto);
            if (token == null) return Unauthorized("Credenciais inválidas.");
            return Ok(new { token });
        }

        [HttpGet("usuario")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email)) return Unauthorized();

            var usuario = await _usuarioService.GetUsuarioLogadoAsync(email);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }
    }
}
