using EngenhariaObrasApi.DTOs;

namespace EngenhariaObrasApi.Services.Interfaces
{
    public interface IObraService
    {
        Task<IEnumerable<ObraDTO>> GetAllAsync();
        Task<ObraDTO?> GetByIdAsync(int id);
        Task<ObraDTO> CreateAsync(ObraCreateDTO dto);
        Task<bool> UpdateAsync(int id, ObraCreateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> AssociarMaterialAsync(int idObra, int idMaterial, int quantidade);
        Task<IEnumerable<MaterialDTO>> GetMateriaisDaObraAsync(int idObra);
        Task<IEnumerable<MaterialDTO>> GetMateriaisNaoAssociadosAsync(int idObra);
        Task<bool> RemoverMaterialAsync(int idObra, int idMaterial);
        Task<decimal> CalcularTotalObraAsync(int idObra);
        Task<bool> AtualizarQuantidadeMaterialAsync(int idObra, int idMaterial, int novaQuantidade);
    }
}
