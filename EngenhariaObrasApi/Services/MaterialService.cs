using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EngenhariaObrasApi.Data;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;
using EngenhariaObrasApi.Services.Interfaces;

namespace EngenhariaObrasApi.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MaterialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllAsync()
        {
            var lista = await _context.Materiais.ToListAsync();
            return _mapper.Map<IEnumerable<MaterialDTO>>(lista);
        }

        public async Task<MaterialDTO?> GetByIdAsync(int id)
        {
            var item = await _context.Materiais.FindAsync(id);
            return item == null ? null : _mapper.Map<MaterialDTO>(item);
        }

        public async Task<MaterialDTO> CreateAsync(MaterialCreateDTO dto)
        {
            var entity = _mapper.Map<Material>(dto);
            _context.Materiais.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<MaterialDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, MaterialCreateDTO dto)
        {
            var entity = await _context.Materiais.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Materiais.FindAsync(id);
            if (entity == null) return false;

            _context.Materiais.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
