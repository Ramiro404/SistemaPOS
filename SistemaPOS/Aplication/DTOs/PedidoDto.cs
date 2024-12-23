using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Aplication.DTOs
{
    public class PedidoDto
    {
        public int Id { get;  set; }
        public DateTime? FechaFacturacion { get;  set; }
        public DateTime? FechaCierre { get;  set; }
        public ClienteDto Cliente { get;  set; }
        public ProductoDto Producto { get;  set; }
        public int Cantidad { get; set; }
    }

    public class PedidoPendienteDto
    {
        public int ClienteId { get; set; }
        public string NumeroDocumento { get; set; }
        public int Unidades {  get; set; }
    }

    public class PedidoFacturadoDto
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public int Unidades { get; set; }
        public DateTime FechaFacturacion { get; set; }

    }
}
