using SistemaPOS.Domain.Entities;

namespace SistemaPOS.Aplication.DTOs
{
    public class PedidoDto
    {
        public int Id { get;  set; }
        public DateTime? FechaFacturacion { get;  set; }
        public DateTime? FechaCierre { get;  set; }
        public ClienteDto Cliente { get;  set; }
        public ProductoDto ProductO { get;  set; }

    }
}
