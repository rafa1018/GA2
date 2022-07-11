using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class RequestDocumentoSolicCreditoDto
    {
        [Key]
        public Guid idSolicitudCredito { get; set; }
        public int idTipoDocumento { get; set; }
        public string codigoBarras { get; set; }
        public string rutaImagen { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
