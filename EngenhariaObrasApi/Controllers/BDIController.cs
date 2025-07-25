﻿using Microsoft.AspNetCore.Mvc;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using EngenhariaObrasApi.Services;


namespace EngenhariaObrasApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BDIController : ControllerBase
    {
        private readonly IBDIService _service;

        public BDIController(IBDIService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BDIDTO>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BDIDTO>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<BDIDTO>> Create(BDICreateDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BDICreateDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("calcular/{idObra}")]
        public async Task<IActionResult> CalcularBDI(int idObra)
        {
            var resultado = await _service.CalcularBDIAsync(idObra);
            return resultado == null
                ? NotFound("BDI ou Obra não encontrada.")
                : Ok(new { BDI = $"{resultado}%" });
        }
    }
}
