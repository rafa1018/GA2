using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DesistimientoDesembolsoDto
    {
        public Guid IdSolicitudDesistimiento { get; set; }
        public Guid IdSolicitudCredito { get; set; }
        public int IdFuenteRecursos { get; set; }
        public int ValorDesembolso { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public string Aplicado { get; set; }
        public Guid AplicadoPor { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public string Anulado { get; set; }
        public int IdCdd { get; set; }
        public Guid AnuladoPor { get; set; }
        public DateTime FechaAnulacion { get; set; }
        public string ObservacionAnulacion { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
    }
}
