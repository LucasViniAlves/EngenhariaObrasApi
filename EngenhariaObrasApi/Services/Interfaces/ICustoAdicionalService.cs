using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Services.Interfaces
{
    public interface IBDIService
    {
        Task<IEnumerable<BDIDTO>> GetAllAsync();
        Task<BDIDTO?> GetByIdAsync(int id);
        Task<BDIDTO> CreateAsync(BDICreateDTO dto);
        Task<bool> UpdateAsync(int id, BDICreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
