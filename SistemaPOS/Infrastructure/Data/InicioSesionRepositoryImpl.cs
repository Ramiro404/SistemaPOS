using Microsoft.EntityFrameworkCore;
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
            return resultado.Id;
        }
    }
}
