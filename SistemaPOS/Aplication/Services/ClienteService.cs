using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task CrearClienteAsync(CrearClienteDto clienteDto)
        {
            Cliente cliente = new Cliente(
                clienteDto.NumeroDocumento,
                clienteDto.Correo,
                clienteDto.Telefono,
                clienteDto.Direccion,
                clienteDto.Departamento,
                clienteDto.Ciudad,
                clienteDto.Colonia
                );
            await _clienteRepository.CrearCliente(cliente);
        }

        public async Task<Cliente> EditarClienteAsync(int id, EditarClienteDto clienteDto)
        {
            Cliente cliente = new Cliente(
                clienteDto.NumeroDocumento,
                clienteDto.Correo,
                clienteDto.Telefono,
                clienteDto.Direccion,
                clienteDto.Departamento,
                clienteDto.Ciudad,
                clienteDto.Colonia
                );
            return await _clienteRepository.EditarCliente(id, cliente);
        }

        public async Task EliminarClienteAsync(int id)
        {
            await _clienteRepository.EliminarCliente(id);
        }

        public async Task<List<ClienteDto>> ListarClienteAsync()
        {
            return await _clienteRepository.ListarCliente();
        }
    }
}
