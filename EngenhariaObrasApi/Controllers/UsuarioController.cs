using Microsoft.AspNetCore.Mvc;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using EngenhariaObrasApi.Services;
using System.Reflection.Metadata.Ecma335;

namespace EngenhariaObrasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAllUsuarios();
            return Ok(usuarios);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioCreateDTO dto) {
            var updated = await _usuarioService.updateUsuarioById(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}
