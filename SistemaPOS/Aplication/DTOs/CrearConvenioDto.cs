namespace SistemaPOS.Aplication.DTOs
{
    public class CrearConvenioDto
    {
        public string Nombre { get;  set; }
        public string Descripcion { get;  set; }
        public int PorcentajeDescuento { get; set; }
    }
    public class EditarConvenioDto: CrearConvenioDto { }
}
