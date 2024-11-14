using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Domain.Repositories
{
    public interface ClienteRepository
    {
        public Task CrearCliente(Cliente cliente);
        public Task<Cliente> EditarCliente(int id, Cliente cliente);
        public Task EliminarCliente(int id);
        public Task<List<ClienteDto>> ListarCliente();
    }
}
