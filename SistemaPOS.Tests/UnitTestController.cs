using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using SistemaPOS.API;
using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Aplication.Services;
using SistemaPOS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Tests
{
    public class UnitTestController
    {
        private readonly ClienteService _clienteService;
        private readonly ClienteRepository _clienteRepository;

        public UnitTestController()
        {
            _clienteRepository = new Mock<ClienteRepository>().Object;
            _clienteService = new ClienteService(_clienteRepository);

        }

        [Fact]
        public async void CrearCliente()
        {
            // arrange
            CrearClienteDto crearClienteDto = new CrearClienteDto { 
            NumeroDocumento = "1234",
            Correo= "cmail.com",
            Telefono= "1231231234",
            Direccion= "Calle PATO 101",
            Departamento= "Uno",
            Ciudad= "Juarez",
            Colonia= "Malavista"
            };

            var clienteController  = new ClienteController(_clienteService);

            //act
            var result = await clienteController.Crear(crearClienteDto);

            //assert
            
            Assert.NotNull(result);


        }
    }
}
