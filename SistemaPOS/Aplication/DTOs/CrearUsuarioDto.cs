namespace SistemaPOS.Aplication.DTOs
{
    public class CrearUsuarioDto
    {
        public string Nombre { get;  set; }
        public string ApellidoPaterno { get;  set; }
        public string ApellidoMaterno { get;  set; }
        public string User { get;  set; }
        public string Password { get;  set; }
        public string HoraEntrada { get;  set; }
        public string HoraSalida { get;  set; }
        public DateTime? FechaInicioSesion { get;  set; }
        public DateTime? FechaCierreSesion { get;  set; }
    }

    public class EditarUsuarioDto {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
    }
}
