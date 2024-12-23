using Microsoft.EntityFrameworkCore;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;

namespace SistemaPOS.Infrastructure.Data
{
    public class UsuarioRepositoryImpl : UsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CrearUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> EditarUsuario(int id, Usuario usuario)
        {
            var usuarioEditar = await _context.Usuarios.FindAsync(id);
            if(usuarioEditar != null)
            {
                usuarioEditar.Actualizar(
                    usuario.Nombre,
                    usuario.ApellidoPaterno,
                    usuario.ApellidoMaterno,
                    usuario.HoraEntrada,
                    usuario.HoraSalida,
                    usuario.FechaInicioSesion,
                    usuario.FechaCierreSesion
                    );
                _context.Entry(usuarioEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return usuarioEditar;
            }
            throw new Exception("No se encontro el usuario");
        }

        public async Task EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if( usuario != null)
            {
                usuario.Eliminar();
                _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return;
            }
            throw new Exception("No se encontro el usuario");
        }

        public async Task<List<Usuario>> ListarUsuario()
        {
            return await (
                from u in _context.Usuarios
                where !u.Eliminado
                select u
                ).ToListAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if(usuario != null)
            {
                return usuario;
            }
            throw new Exception("No se encontro el usuario");
        }

    }
}
