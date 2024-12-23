using Microsoft.EntityFrameworkCore;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;

namespace SistemaPOS.Infrastructure.Data
{
    public class InicioSesionRepositoryImpl : InicioSesionRepository
    {
        private readonly ApplicationDbContext _context;

        public InicioSesionRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Ingresar(string usuario, string password)
        {
            var resultado = await (
                from us in _context.Usuarios
                where us.User.Equals(usuario) && us.Password.Equals(password)
                select us).FirstOrDefaultAsync();

            if(resultado == null)
            {
                throw new Exception("Usuario o Password incorrecto");
            }
            await GuardarFechaYHoraIngreso(resultado);
            return resultado.Id;
        }

        private async Task GuardarFechaYHoraIngreso(Usuario usuario)
        {
            usuario.RegistrarIngreso();
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private async Task GuardarFechaYHoraSalida(Usuario usuario)
        {
            usuario.RegistrarSalida();
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
