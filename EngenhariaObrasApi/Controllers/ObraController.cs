using Microsoft.AspNetCore.Mvc;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EngenhariaObrasApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ObraController : ControllerBase
    {
        private readonly IObraService _obraService;

        public ObraController(IObraService obraService)
        {
            _obraService = obraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObraDTO>>> GetAll()
        {
            var obras = await _obraService.GetAllAsync();
            return Ok(obras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObraDTO>> GetById(int id)
        {
            var obra = await _obraService.GetByIdAsync(id);
            if (obra == null) return NotFound();
            return Ok(obra);
        }

        [HttpPost]
        public async Task<ActionResult<ObraDTO>> Create(ObraCreateDTO dto)
        {
            var novaObra = await _obraService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = novaObra.Id }, novaObra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ObraCreateDTO dto)
        {
            var atualizado = await _obraService.UpdateAsync(id, dto);
            if (!atualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _obraService.DeleteAsync(id);
            if (!removido) return NotFound();
            return NoContent();
        }

        [HttpPost("{idObra}/associar-material")]
        public async Task<IActionResult> AssociarMaterial(int idObra, [FromBody] ObraMaterialDTO dto)
        {
            var sucesso = await _obraService.AssociarMaterialAsync(idObra, dto.IdMaterial, dto.Quantidade);
            if (!sucesso) return BadRequest("Erro ao associar material.");
            return Ok();
        }

        [HttpGet("{idObra}/materiais")]
        public async Task<ActionResult> GetMateriaisDaObra(int idObra)
        {
            var materiais = await _obraService.GetMateriaisDaObraAsync(idObra);
            return Ok(materiais);
        }

        [HttpGet("{idObra}/materiais-nao-associados")]
        public async Task<ActionResult> GetMateriaisNaoAssociados(int idObra)
        {
            var materiais = await _obraService.GetMateriaisNaoAssociadosAsync(idObra);
            return Ok(materiais);
        }

        [HttpDelete("{idObra}/remover-material/{idMaterial}")]
        public async Task<IActionResult> RemoverMaterial(int idObra, int idMaterial)
        {
            var sucesso = await _obraService.RemoverMaterialAsync(idObra, idMaterial);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpGet("{idObra}/total")]
        public async Task<ActionResult<decimal>> GetTotalObra(int idObra)
        {
            try
            {
                var total = await _obraService.CalcularTotalObraAsync(idObra);
                return Ok(total);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{idObra}/materiais/{idMaterial}")]
        public async Task<IActionResult> AtualizarQuantidadeMaterial(int idObra, int idMaterial, [FromBody] AtualizarQuantidadeDTO dto)
        {
            if (dto.Quantidade <= 0)
                return BadRequest("Quantidade deve ser maior que zero.");

            var atualizado = await _obraService.AtualizarQuantidadeMaterialAsync(idObra, idMaterial, dto.Quantidade);

            if (!atualizado)
                return NotFound("Associação obra-material não encontrada.");

            return NoContent();
        }
    }
}
