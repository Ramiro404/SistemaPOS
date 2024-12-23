using SistemaPOS.Aplication.DTOs;
using SistemaPOS.Domain.Entities;
using SistemaPOS.Domain.Repositories;

namespace SistemaPOS.Aplication.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task CrearProductoAsync(CrearProductoDto crearProductoDto)
        {
            var producto = new Producto(
                crearProductoDto.Nombre,
                crearProductoDto.ValorUnitario,
                crearProductoDto.Medida,
                crearProductoDto.UnidadMedida,
                crearProductoDto.Peso,
                crearProductoDto.VolumenEmpaque);
            await _productoRepository.CrearProducto(producto);

        }

        public async Task EditarProductoAsync(int id, EditarProductoDto editarProductoDto)
        {
            var producto = new Producto(
                editarProductoDto.Nombre,
                editarProductoDto.ValorUnitario,
                editarProductoDto.Medida,
                editarProductoDto.UnidadMedida,
                editarProductoDto.Peso,
                editarProductoDto.VolumenEmpaque);
            await _productoRepository.EditarProducto(id, producto);
        }

        public async Task EliminarProductoAsync(int id)
        {
            await _productoRepository.EliminarProducto(id);
        }

        public async Task<List<ProductoDto>> ListarProductoAsync()
        {
            return await _productoRepository.ListarProductos();
        }

        public async Task IngresarInventarioAsync(int productoId, int cantidad)
        {
            await _productoRepository.IngresarInventario(productoId, cantidad);
        }

        public async Task DescontarInventarioAsync(int productoId, int cantidad)
        {
            await _productoRepository.DescontarInventario(productoId, cantidad);
        }

        public async Task<ProductoDto> ObtenerPorIdAsync(int id)
        {
            var producto =  await _productoRepository.ObtenerProductoPorId(id);
            return new ProductoDto {
                Id=producto.Id,
                Medida=producto.Medida,
                Nombre=producto.Nombre,
                Peso = producto.Peso,
                ValorUnitario = producto.ValorUnitario,
                UnidadMedida = producto.UnidadMedida,
                VolumenEmpaque = producto.VolumenEmpaque
            };
        }
    }
}
