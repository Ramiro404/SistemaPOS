namespace SistemaPOS.Aplication.DTOs
{
    public class CrearMedioPagoDto
    {
        public string Nombre { get;  set; }
        public string Descripcion { get;  set; }
    }

    public class EditarMedioPago: CrearMedioPagoDto { }
}
