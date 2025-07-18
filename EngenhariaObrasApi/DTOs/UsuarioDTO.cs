using EngenhariaObrasApi.Models.Enums;

namespace EngenhariaObrasApi.DTOs
{
    public class UsuarioDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Perfil { get; set; } = PerfilConstants.Visitante;
    }
}
