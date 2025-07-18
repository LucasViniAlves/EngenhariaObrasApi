using Microsoft.AspNetCore.Mvc;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EngenhariaObrasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDTO>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [Authorize(Roles = "Proprietario, Colaborador")]
        [HttpPost]
        public async Task<ActionResult<MaterialDTO>> Create(MaterialCreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [Authorize(Roles = "Proprietario, Colaborador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MaterialCreateDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "Proprietario, Colaborador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
