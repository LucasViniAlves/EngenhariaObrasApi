using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EngenhariaObrasApi.Data;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;
using EngenhariaObrasApi.Services.Interfaces;

namespace EngenhariaObrasApi.Services
{
    public class BDIService : IBDIService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BDIService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BDIDTO>> GetAllAsync()
        {
            var lista = await _context.BDIs.ToListAsync();
            return _mapper.Map<IEnumerable<BDIDTO>>(lista);
        }

        public async Task<BDIDTO?> GetByIdAsync(int id)
        {
            var item = await _context.BDIs.FindAsync(id);
            return item == null ? null : _mapper.Map<BDIDTO>(item);
        }

        public async Task<BDIDTO> CreateAsync(BDICreateDTO dto)
        {
            var entity = _mapper.Map<BDI>(dto);
            _context.BDIs.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<BDIDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, BDICreateDTO dto)
        {
            var entity = await _context.BDIs.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.BDIs.FindAsync(id);
            if (entity == null) return false;

            _context.BDIs.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal?> CalcularBDIAsync(int idObra)
        {
            var bdi = await _context.BDIs
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.ObraId == idObra);

            if (bdi == null) return null;

            var obra = await _context.Obras
                .Include(o => o.ObrasMateriais)
                    .ThenInclude(om => om.Material)
                .Include(o => o.MaoDeObras)
                .FirstOrDefaultAsync(o => o.Id == idObra);

            if (obra == null) return null;

            decimal custoMateriais = obra.ObrasMateriais
                .Sum(om => om.Material.PrecoUnitario * om.Material.Quantidade);

            decimal custoMaoDeObra = obra.MaoDeObras
                .Sum(m => m.ValorHora * m.HorasTrabalhadas);

            decimal custoDireto = custoMateriais + custoMaoDeObra;
            if (custoDireto == 0) return 0;

            decimal somaComponentes = 
                  bdi.AdministracaoCentral
                + bdi.AdministracaoLocal
                + bdi.DespesasIndiretas
                + bdi.DespesaFinanceira
                + bdi.PosObras
                + bdi.Risco
                + bdi.Impostos
                + bdi.MargemLucro
                + bdi.Seguro
                + bdi.ReservaTecnica;

            decimal bdiPercentual = (somaComponentes / custoDireto) * 100;

            return Math.Round(bdiPercentual, 2);
        }
    }
}
