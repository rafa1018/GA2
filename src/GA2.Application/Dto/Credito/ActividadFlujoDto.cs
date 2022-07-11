using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Propiedades Dto de ActividadFlujoDto
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>24/04/2021</date>
    public class ActividadFlujoDto
    {
        public int Id { get; set; }
        public int FluId { get; set; }
        public int TacId { get; set; }
        public int Orden { get; set; }
        public int Tiempo { get; set; }
        public char ActividadAutomatica { get; set; }
        public char ActividadPrincipal { get; set; }
        public char PuedeDelegar { get; set; }
        public char CargarArchivos { get; set; }
        public char VisualizarArchivos { get; set; }
        public char CapturaDatosTec { get; set; }
        public char CapturaDatosJur { get; set; }
        public char CapturaDatosFin { get; set; }
        public char VisualizaDatosBas { get; set; }
        public char VisualizaDatosGar { get; set; }
        public char VisualizaDatosFin { get; set; }
        public char GeneraPdfResumen { get; set; }
        public char ConsultaBuro { get; set; }
        public char EnvioNotificacion { get; set; }
        public char EnvioNotificacionVenc { get; set; }
        public char EnvioNotificacionCliente { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
