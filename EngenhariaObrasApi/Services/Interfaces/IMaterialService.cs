using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDTO>> GetAllAsync();
        Task<MaterialDTO?> GetByIdAsync(int id);
        Task<MaterialDTO> CreateAsync(MaterialCreateDTO dto);
        Task<bool> UpdateAsync(int id, MaterialCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
