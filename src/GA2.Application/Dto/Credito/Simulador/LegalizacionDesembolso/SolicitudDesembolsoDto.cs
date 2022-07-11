using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudDesembolsoDto
    {
        public Guid IdSolicitudDesembolso { get; set; }
        public Guid IdSolicitudCredito { get; set; }
        public string NumeroSolicitud { get; set; }
        public string TipoCredito { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdFuenteRecursos { get; set; }
        public string FuenteRecursos { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public int ValorDesembolso { get; set; }
        public string Aplicado { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public Guid? AplicadoPor { get; set; }
        public string Anulado { get; set; }
        public DateTime FechaAnulacion { get; set; }
        public string ObservacionAnulacion { get; set; }
        public Guid AnuladoPor { get; set; }
        public string CausaAnulacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
