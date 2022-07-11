using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto.Credito.Simulador
{
    public class SimulacionSolicitudDto
    {
        public Guid IdSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int TcrId { get; set; }
        public Int64 NumeroPreaprobado { get; set; }
        public int ProblemaEmail { get; set; }
        public int EnvioNotificacion { get; set; }
        public string RutaPdfResumen { get; set; }
        public string Estado { get; set; }
        public Guid UsuarioActualiza { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}
