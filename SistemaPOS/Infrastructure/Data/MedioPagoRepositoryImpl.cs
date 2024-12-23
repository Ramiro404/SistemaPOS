using Microsoft.EntityFrameworkCore;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;

namespace SistemaPOS.Infrastructure.Data
{
    public class MedioPagoRepositoryImpl : MedioPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public MedioPagoRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CrearMedioPago(MedioPago medioPago)
        {
            _context.MedioPagos.Add(medioPago);
            await _context.SaveChangesAsync();
        }

        public async Task EditarMedioPago(int id, MedioPago medioPago)
        {
            var medioPagoEditar = await _context.MedioPagos.FindAsync(id);
            if(medioPagoEditar != null) {
                medioPagoEditar.Actualizar(
                    medioPago.Nombre,
                    medioPago.Descripcion);
                _context.Entry(medioPagoEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se encontro el medio de pago");
            }
        }

        public async Task EliminarMedioPago(int id)
        {
            var medioPago = await _context.MedioPagos.FindAsync(id);
            if(medioPago != null)
            {
                medioPago.Eliminar();
                _context.Entry(medioPago).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No se encontro el medio de pago");
            }

        }

        public async Task<List<MedioPago>> ListarMedioPago()
        {
            return await (
                from mp in _context.MedioPagos
                where !mp.Eliminado
                select mp).ToListAsync();
        }
    }
}
