﻿using System.Security.Cryptography;
using System.Text;
using EngenhariaObrasApi.Data;
using EngenhariaObrasApi.DTOs;
using EngenhariaObrasApi.Models;
using EngenhariaObrasApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EngenhariaObrasApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public UsuarioService(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string?> RegistrarAsync(UsuarioRegisterDTO dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                return null;

            using var hmac = new HMACSHA512();

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Senha)),
                SenhaSalt = hmac.Key,
                Perfil = dto.Perfil
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return _tokenService.GerarToken(usuario);
        }

        public async Task<string?> LoginAsync(UsuarioLoginDTO dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (usuario == null) return null;

            using var hmac = new HMACSHA512(usuario.SenhaSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Senha));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != usuario.SenhaHash[i]) return null;
            }

            return _tokenService.GerarToken(usuario);
        }

        public async Task<UsuarioDTO?> GetUsuarioLogadoAsync(string email)
        {
            var usuario = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null) return null;

            return new UsuarioDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }

        public async Task<List<UsuarioDTO>> GetAllUsuarios()
        {
            var usuarios = await _context.Usuarios
                .AsNoTracking()
                .Select(u => new UsuarioDTO
                {
                    Nome = u.Nome,
                    Email = u.Email,
                    Perfil = u.Perfil
                })
                .ToListAsync();
            return usuarios;
        }

        public async Task<bool> updateUsuarioById(int id, UsuarioCreateDTO dto)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return false;

            entity.Email = dto.Email;
            entity.Perfil = dto.Perfil;
            entity.Nome = dto.Nome;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
