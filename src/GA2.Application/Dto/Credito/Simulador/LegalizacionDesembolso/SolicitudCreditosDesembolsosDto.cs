using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudCreditosDesembolsosDto
    {
        public Guid idSolicitudCredito { get; set; }
        public string aplicado { get; set; }
        public int numeroSolicitud { get; set; }
        public string tipoCredito { get; set; }
        public Guid idSolicitudDesembolso { get; set; }
        public string documentoCliente { get; set; }
        public string nombreCliente { get; set; }
        public int idFuenteRecursos { get; set; }
        public string fuenteRecursos { get; set; }
        public DateTime fechaDesembolso { get; set; }
        public int valorDesembolso { get; set; }
        public DateTime fechaAplicacion { get; set; }
        public Guid aplicadoPor { get; set; }
        public string anulado { get; set; }
        public DateTime fechaAnulacion { get; set; }
        public string observacionAnulacion { get; set; }
        public Guid anuladoPor { get; set; }
        public string causaAnulacion { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Guid actualizadoPor { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string DescripcionFuenteRecursos { get; set; }
    }
}
