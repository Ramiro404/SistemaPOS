﻿namespace SistemaPOS.Aplication.DTOs
{
    public class UsuarioDto
    {
        public int Id { get;  set; }
        public string Nombre { get;  set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get;  set; }
        public DateTime? FechaInicioSesion { get;  set; }
        public DateTime? FechaCierreSesion { get;    set; }
    }
}
