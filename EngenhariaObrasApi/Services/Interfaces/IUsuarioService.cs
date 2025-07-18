using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;

namespace EngenhariaObrasApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<string?> RegistrarAsync(UsuarioRegisterDTO dto);
        Task<string?> LoginAsync(UsuarioLoginDTO dto);
        Task<UsuarioDTO?> GetUsuarioLogadoAsync(string email);
        Task<List<UsuarioDTO>> GetAllUsuarios();
        Task<bool> updateUsuarioById(int id, UsuarioCreateDTO dto);
    }
}
