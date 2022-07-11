using System;
namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto Solicitud Simulacion
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public class SolicitudSimulacionDto
    {
        public Guid Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int TcrId { get; set; }
        public int NumeroPreAprobado { get; set; }
        public bool ProblemaEmail { get; set; }
        public bool EnvioNotificacion { get; set; }
        public string Estado { get; set; }
        public Guid UsuarioActualiza { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}
