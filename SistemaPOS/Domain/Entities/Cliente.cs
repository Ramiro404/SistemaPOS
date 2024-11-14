namespace SistemaPOS.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string NumeroDocumento { get; private set; }
        public string Correo {  get; private set; }
        public string Telefono { get; private set; }
        public string Direccion {  get; private set; }
        public string Departamento { get; private set; }
        public string Ciudad {  get; private set; }
        public string Colonia { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }
        public bool Eliminado { get; private set; }

        public List<Pedido> Pedidos { get; private set; }

        public Cliente() { }

        public Cliente(string numeroDocumento, string correo, string telefono, string direccion, string departamento, string ciudad, string colonia)
        {
            NumeroDocumento = numeroDocumento;
            Correo = correo;
            Telefono = telefono;
            Direccion = direccion;
            Departamento = departamento;
            Ciudad = ciudad;
            Colonia = colonia;
            Eliminado = false;
            FechaCreacion = DateTime.Now;
        }

        public void Actualizar(string numeroDocumento, string correo, string telefono, string direccion, string departamento, string ciudad, string colonia)
        {
            NumeroDocumento = numeroDocumento;
            Correo = correo;
            Telefono = telefono;
            Direccion = direccion;
            Departamento = departamento;
            Ciudad = ciudad;
            Colonia = colonia;
            Eliminado = false;
            FechaActualizacion = DateTime.Now;
        }

        public void Eliminar()
        {
            Eliminado = true;
        }

    }
}
