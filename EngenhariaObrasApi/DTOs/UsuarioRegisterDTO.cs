using System.ComponentModel.DataAnnotations;
using EngenhariaObrasApi.Models.Enums;

namespace EngenhariaObrasApi.DTOs
{
    public class UsuarioRegisterDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [RegularExpression("Administrador|Gerente|Engenheiro|Cliente|Visitante", ErrorMessage = "Perfil inválido.")]
        public string Perfil { get; set; } = PerfilConstants.Visitante;
    }
}
