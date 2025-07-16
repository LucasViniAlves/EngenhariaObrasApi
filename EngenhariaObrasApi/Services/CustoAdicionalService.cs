using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EngenhariaObrasApi.Data;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;
using EngenhariaObrasApi.Services.Interfaces;

namespace EngenhariaObrasApi.Services
{
    public class CustoAdicionalService : ICustoAdicionalService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustoAdicionalService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustoAdicionalDTO>> GetAllAsync()
        {
            var lista = await _context.CustosAdicionais.ToListAsync();
            return _mapper.Map<IEnumerable<CustoAdicionalDTO>>(lista);
        }

        public async Task<CustoAdicionalDTO?> GetByIdAsync(int id)
        {
            var item = await _context.CustosAdicionais.FindAsync(id);
            return item == null ? null : _mapper.Map<CustoAdicionalDTO>(item);
        }

        public async Task<CustoAdicionalDTO> CreateAsync(CustoAdicionalCreateDTO dto)
        {
            var entity = _mapper.Map<CustoAdicional>(dto);
            _context.CustosAdicionais.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustoAdicionalDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, CustoAdicionalCreateDTO dto)
        {
            var entity = await _context.CustosAdicionais.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CustosAdicionais.FindAsync(id);
            if (entity == null) return false;

            _context.CustosAdicionais.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
