using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Services.Interfaces
{
    public interface IMaoDeObraService
    {
        Task<IEnumerable<MaoDeObraDTO>> GetAllAsync();
        Task<MaoDeObraDTO?> GetByIdAsync(int id);
        Task<MaoDeObraDTO> CreateAsync(MaoDeObraCreateDTO dto);
        Task<bool> UpdateAsync(int id, MaoDeObraCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
