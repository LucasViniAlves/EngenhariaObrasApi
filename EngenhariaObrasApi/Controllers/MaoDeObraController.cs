using Microsoft.AspNetCore.Mvc;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EngenhariaObrasApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MaoDeObraController : ControllerBase
    {
        private readonly IMaoDeObraService _service;

        public MaoDeObraController(IMaoDeObraService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaoDeObraDTO>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<MaoDeObraDTO>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [Authorize(Roles = "Proprietario,Colaborador")]
        [HttpPost]
        public async Task<ActionResult<MaoDeObraDTO>> Create(MaoDeObraCreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [Authorize(Roles = "Proprietario,Colaborador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MaoDeObraCreateDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "Proprietario,Colaborador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
