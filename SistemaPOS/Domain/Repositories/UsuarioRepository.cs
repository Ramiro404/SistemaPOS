using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface UsuarioRepository
    {
        public Task CrearUsuario(Usuario usuario);
        public Task<Usuario> EditarUsuario(int id, Usuario usuario);
        public Task EliminarUsuario(int id);
        public Task<List<Usuario>> ListarUsuario();
        public Task<Usuario> ObtenerUsuarioPorId(int id);
    }
}
