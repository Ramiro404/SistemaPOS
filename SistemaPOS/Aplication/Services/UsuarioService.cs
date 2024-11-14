using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CrearUsuarioAsync(CrearUsuarioDto crearUsuarioDto)
        {
            Usuario usuario = new Usuario(
                crearUsuarioDto.Nombre,
                crearUsuarioDto.ApellidoPaterno,
                crearUsuarioDto.ApellidoMaterno,
                crearUsuarioDto.HoraEntrada,
                crearUsuarioDto.HoraSalida);
            await _usuarioRepository.CrearUsuario(usuario);
        }

        public async Task EditarUsuarioDto(int id, EditarUsuarioDto editarUsuarioDto)
        {
            Usuario usuarioEditar = new Usuario(
                editarUsuarioDto.Nombre,
                editarUsuarioDto.ApellidoPaterno,
                editarUsuarioDto.ApellidoMaterno,
                editarUsuarioDto.HoraEntrada,
                editarUsuarioDto.HoraSalida,
                editarUsuarioDto.FechaInicioSesion,
                editarUsuarioDto.FechaCierreSesion);
            await _usuarioRepository.EditarUsuario(id, usuarioEditar);
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            await _usuarioRepository.EliminarUsuario(id);
        }

        public async Task<List<UsuarioDto>> ListarUsuarioDto()
        {
            var lista = await _usuarioRepository.ListarUsuario();
            return lista.Select(u => new UsuarioDto
            {
                Id=u.Id,
                ApellidoMaterno = u.ApellidoMaterno,
                ApellidoPaterno = u.ApellidoPaterno,
                FechaCierreSesion = u.FechaCierreSesion,
                FechaInicioSesion = u.FechaInicioSesion,
                HoraEntrada = u.HoraEntrada,
                HoraSalida = u.HoraSalida,
                Nombre = u.Nombre
            }).ToList();
        }

    }
}
