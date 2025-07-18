using EngenhariaObrasApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EngenhariaObrasApi.DTOs
{
    public class UsuarioCreateDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Perfil { get; set; } = PerfilConstants.Visitante;
    }
}
