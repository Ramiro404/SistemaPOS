using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using System.Globalization;

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
                crearUsuarioDto.User,
                crearUsuarioDto.Password,
                TimeOnly.Parse(crearUsuarioDto.HoraEntrada, CultureInfo.InvariantCulture),
                TimeOnly.Parse(crearUsuarioDto.HoraSalida, CultureInfo.InvariantCulture),
                crearUsuarioDto.FechaInicioSesion,
                crearUsuarioDto.FechaCierreSesion);
            await _usuarioRepository.CrearUsuario(usuario);
        }

        public async Task EditarUsuarioDto(int id, EditarUsuarioDto editarUsuarioDto)
        {
            Usuario usuarioEditar = new Usuario(
                editarUsuarioDto.Nombre,
                editarUsuarioDto.ApellidoPaterno,
                editarUsuarioDto.ApellidoMaterno,
                TimeOnly.Parse(editarUsuarioDto.HoraEntrada, CultureInfo.InvariantCulture),
                TimeOnly.Parse(editarUsuarioDto.HoraSalida, CultureInfo.InvariantCulture)
                );
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
                HoraEntrada = u.HoraEntrada.ToString("t"),
                HoraSalida = u.HoraSalida.ToString("t"),
                Nombre = u.Nombre
            }).ToList();
        }

        public async Task<UsuarioDto> ObtenerUsuarioDtoPorId(int id)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorId(id);
            return new UsuarioDto
            {
                Id = usuario.Id,
                ApellidoMaterno = usuario.ApellidoMaterno,
                ApellidoPaterno = usuario.ApellidoPaterno,
                FechaCierreSesion = usuario.FechaCierreSesion,
                FechaInicioSesion = usuario.FechaInicioSesion,
                HoraEntrada = usuario.HoraEntrada.ToString("t"),
                HoraSalida = usuario.HoraSalida.ToString("t"),
                Nombre = usuario.Nombre
            };
        }


    }
}
