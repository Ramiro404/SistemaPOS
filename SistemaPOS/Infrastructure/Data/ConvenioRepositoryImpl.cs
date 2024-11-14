using Microsoft.EntityFrameworkCore;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;

namespace SistemaPOS.Infrastructure.Data
{
    public class ConvenioRepositoryImpl : ConvenioRepository
    {
        private readonly ApplicationDbContext _context;

        public ConvenioRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CrearConvenio(Convenio convenio)
        {
            _context.Convenios.Add(convenio);
            await _context.SaveChangesAsync();
        }

        public async Task<Convenio> EditarConvenio(int id, Convenio convenio)
        {
            var convenioEditar = await _context.Convenios.FindAsync(id);
            if(convenioEditar != null)
            {
                convenioEditar.Actualizar(
                    convenio.Nombre,
                    convenio.Descripcion,
                    convenio.PorcentajeDescuento);
                _context.Entry(convenioEditar).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return convenioEditar;
            }
            throw new Exception("No se encontro el convenio");
        }

        public async Task EliminarConvenio(int id)
        {
            var convenio = await _context.Convenios.FindAsync(id);
            if(convenio != null)
            {
                convenio.Eliminar();
                _context.Entry(_context).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            throw new Exception("No se encontro el convenio");
        }

        public async Task<List<Convenio>> ListarConvenio()
        {
            return await _context.Convenios.ToListAsync();
        }
    }
}
