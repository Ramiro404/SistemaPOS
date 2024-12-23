namespace SistemaPOS.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }
        public DateTime? FechaFacturacion { get; private set; }
        public DateTime? FechaCierre { get; private set; }
        public bool Eliminado { get; private set; } = false;
        public int ClienteId { get; private set; }
        public int? FacturaId { get; private set; }


        public Pedido() { }

        public Pedido(int clienteId)
        {
            FechaCreacion = DateTime.Now.ToUniversalTime();
            ClienteId = clienteId;
        }

        public Pedido(int pedidoId, int clienteId)
        {
            Id = pedidoId;
            FechaCreacion = DateTime.Now.ToUniversalTime();
            ClienteId = clienteId;
        }


        public void Actualizar(List<Producto> productos)
        {
            //Productos = productos;
            throw new NotImplementedException();
        }

        public void Cerrar()
        {
            FechaCierre = DateTime.Now.ToUniversalTime();
        }

        public void Eliminar()
        {
            Eliminado = true;
        }

        public void setFacturaId(int id)
        {
            this.FacturaId = id;
        }
    }
}
