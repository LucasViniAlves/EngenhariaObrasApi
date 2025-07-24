using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;
using EngenhariaObrasApi.Data;
using EngenhariaObrasApi.Services.Interfaces;

namespace EngenhariaObrasApi.Services
{
    public class ObraService : IObraService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ObraService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObraDTO>> GetAllAsync()
        {
            var obras = await _context.Obras.ToListAsync();
            return _mapper.Map<IEnumerable<ObraDTO>>(obras);
        }

        public async Task<ObraDTO?> GetByIdAsync(int id)
        {
            var obra = await _context.Obras
            .Include(o => o.ObrasMateriais).ThenInclude(om => om.Material)
            .Include(o => o.MaoDeObras)
            .Include(o => o.CustosAdicionais)
            .Include(o => o.BDI)
            .FirstOrDefaultAsync(o => o.Id == id);
            return obra == null ? null : _mapper.Map<ObraDTO>(obra);
        }

        public async Task<ObraDTO> CreateAsync(ObraCreateDTO dto)
        {
            var obra = _mapper.Map<Obra>(dto);
            _context.Obras.Add(obra);
            await _context.SaveChangesAsync();
            return _mapper.Map<ObraDTO>(obra);
        }

        public async Task<bool> UpdateAsync(int id, ObraCreateDTO dto)
        {
            var obra = await _context.Obras.FindAsync(id);
            if (obra == null) return false;

            _mapper.Map(dto, obra);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            if (obra == null) return false;

            _context.Obras.Remove(obra);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssociarMaterialAsync(int idObra, int idMaterial, int quantidade)
        {
            var obra = await _context.Obras.FindAsync(idObra);
            var material = await _context.Materiais.FindAsync(idMaterial);
            if (obra == null || material == null) return false;

            var jaExiste = await _context.ObrasMateriais.AnyAsync(om => om.ObraId == idObra && om.MaterialId == idMaterial);
            if (jaExiste) return false;

            if (material.Quantidade < quantidade) return false; // Verifica se há quantidade suficiente
            material.Quantidade -= quantidade;

            var associacao = new ObrasMateriais
            {
                ObraId = idObra,
                MaterialId = idMaterial,
                Quantidade = quantidade
            };

            _context.ObrasMateriais.Add(associacao);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<MaterialDTO>> GetMateriaisDaObraAsync(int idObra)
        {
            var materiais = await _context.ObrasMateriais
                .Where(om => om.ObraId == idObra)
                .Include(om => om.Material)
                .Select(om => new MaterialDTO
                {
                    Id = om.Material.Id,
                    Nome = om.Material.Nome,
                    PrecoUnitario = om.Material.PrecoUnitario,
                    Quantidade = om.Quantidade
                })
                .ToListAsync();

            return materiais;
        }
        public async Task<IEnumerable<MaterialDTO>> GetMateriaisNaoAssociadosAsync(int idObra)
        {
            var idsAssociados = await _context.ObrasMateriais
                .Where(om => om.ObraId == idObra)
                .Select(om => om.MaterialId)
                .ToListAsync();

            var naoAssociados = await _context.Materiais
                .Where(m => !idsAssociados.Contains(m.Id))
                .Select(m => new MaterialDTO
                {
                    Id = m.Id,
                    Nome = m.Nome,
                    PrecoUnitario = m.PrecoUnitario
                })
                .ToListAsync();

            return naoAssociados;
        }
        public async Task<bool> RemoverMaterialAsync(int idObra, int idMaterial)
        {
            var associacao = await _context.ObrasMateriais
                .FirstOrDefaultAsync(om => om.ObraId == idObra && om.MaterialId == idMaterial);

            if (associacao == null) return false;

            _context.ObrasMateriais.Remove(associacao);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<decimal> CalcularTotalObraAsync(int idObra)
        {
            var obra = await _context.Obras
                .Include(o => o.ObrasMateriais).ThenInclude(om => om.Material)
                .Include(o => o.MaoDeObras)
                .Include(o => o.CustosAdicionais)
                .FirstOrDefaultAsync(o => o.Id == idObra);

            if (obra == null) throw new Exception("Obra não encontrada");

            var totalMateriais = obra.ObrasMateriais.Sum(m => m.Material.PrecoUnitario * m.Quantidade);
            var totalMaoDeObra = obra.MaoDeObras.Sum(m => m.ValorHora * m.HorasTrabalhadas);
            var totalCustosAdicionais = obra.CustosAdicionais.Sum(c => c.Valor);

            return totalMateriais + totalMaoDeObra + totalCustosAdicionais;
        }
        public async Task<bool> AtualizarQuantidadeMaterialAsync(int idObra, int idMaterial, int novaQuantidade)
        {
            var associacao = await _context.ObrasMateriais
                .FirstOrDefaultAsync(om => om.ObraId == idObra && om.MaterialId == idMaterial);

            if (associacao == null) return false;

            associacao.Quantidade = novaQuantidade;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
