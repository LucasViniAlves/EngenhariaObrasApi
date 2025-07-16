using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EngenhariaObrasApi.Data;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;
using EngenhariaObrasApi.Services.Interfaces;

namespace EngenhariaObrasApi.Services
{
    public class MaoDeObraService : IMaoDeObraService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MaoDeObraService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaoDeObraDTO>> GetAllAsync()
        {
            var lista = await _context.MaoDeObras.ToListAsync();
            return _mapper.Map<IEnumerable<MaoDeObraDTO>>(lista);
        }

        public async Task<MaoDeObraDTO?> GetByIdAsync(int id)
        {
            var item = await _context.MaoDeObras.FindAsync(id);
            return item == null ? null : _mapper.Map<MaoDeObraDTO>(item);
        }

        public async Task<MaoDeObraDTO> CreateAsync(MaoDeObraCreateDTO dto)
        {
            var entity = _mapper.Map<MaoDeObra>(dto);
            _context.MaoDeObras.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<MaoDeObraDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, MaoDeObraCreateDTO dto)
        {
            var entity = await _context.MaoDeObras.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.MaoDeObras.FindAsync(id);
            if (entity == null) return false;

            _context.MaoDeObras.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
