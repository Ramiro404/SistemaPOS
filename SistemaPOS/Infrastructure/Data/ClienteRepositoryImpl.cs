using Microsoft.EntityFrameworkCore;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;
using SistemaPOS.Infrastructure.Persistence;
using SistemaPOS.Utils;

namespace SistemaPOS.Infrastructure.Data
{
    public class ClienteRepositoryImpl : ClienteRepository
    {
        private readonly ApplicationDbContext _context;
        public ClienteRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CrearCliente(Cliente cliente)
        {
            string clienteCorreo = cliente.Correo.ToLower();
            var clienteExistente = await _context.Clientes.FirstOrDefaultAsync(x => x.Correo.ToLower() == clienteCorreo);
            if(clienteExistente != null) {
                throw new Exception("Este cliente ya existe");
            }
            if(!RegexUtils.IsValidEmail(clienteCorreo))
            {
                throw new Exception("Correo no valido");
            }
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> EditarCliente(int id, Cliente cliente)
        {
            var clienteEditar = await _context.Clientes.FindAsync(id);
            if(clienteEditar != null)
            {
                EsClienteEliminado(clienteEditar.Eliminado);
                clienteEditar.Actualizar(
                    cliente.NumeroDocumento,
                    cliente.Correo,
                    cliente.Telefono,
                    cliente.Direccion,
                    cliente.Departamento,
                    cliente.Ciudad,
                    cliente.Colonia);
                _context.Entry(clienteEditar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return clienteEditar;
            }
            throw new Exception("No se encontro el cliente");
        }

        public async Task EliminarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente != null)
            {
                EsClienteEliminado(cliente.Eliminado);
                cliente.Eliminar();
                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return;
            }
            throw new Exception("No se encontro el cliente");
        }

        public async Task<List<ClienteDto>> ListarCliente()
        {
            return await (
                from c in _context.Clientes
                where !c.Eliminado 
                select new ClienteDto
                {
                    Id = c.Id,
                    Ciudad = c.Ciudad,
                    Colonia = c.Colonia,
                    Correo = c.Correo,
                    Telefono = c.Telefono,
                    Departamento = c.Departamento,
                    Direccion = c.Direccion,
                    NumeroDocumento = c.NumeroDocumento
                }).ToListAsync();
        }

        private void EsClienteEliminado(bool eliminado)
        {
            if (eliminado)
            {
                throw new Exception("Cliente eliminado");
            }
        }
    }
}
