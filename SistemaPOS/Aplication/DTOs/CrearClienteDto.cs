namespace SistemaPOS.Aplication.DTOs
{
    public class CrearClienteDto
    {
        public string NumeroDocumento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
    }

    public class EditarClienteDto: CrearClienteDto { }
}
