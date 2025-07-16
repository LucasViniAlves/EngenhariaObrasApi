using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Services.Interfaces
{
    public interface ICustoAdicionalService
    {
        Task<IEnumerable<CustoAdicionalDTO>> GetAllAsync();
        Task<CustoAdicionalDTO?> GetByIdAsync(int id);
        Task<CustoAdicionalDTO> CreateAsync(CustoAdicionalCreateDTO dto);
        Task<bool> UpdateAsync(int id, CustoAdicionalCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
