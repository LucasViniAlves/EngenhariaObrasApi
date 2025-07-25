﻿using System.ComponentModel.DataAnnotations;
using EngenhariaObrasApi.Models.ENum;
using EngenhariaObrasApi.Models.Enums;

namespace EngenhariaObrasApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] SenhaHash { get; set; }

        [Required]
        public byte[] SenhaSalt { get; set; }

        [Required]
        public string Perfil { get; set; }

    }
}
