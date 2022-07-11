using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class ResponseDocumentoSolicCreditoDto
    {
        [Key]
        public Guid idDocumentoSolicitud { get; set; }
        public Guid idSolicitudCredito { get; set; }
        public int idTipoDocumento { get; set; }
        public string codigoBarras { get; set; }
        public DateTime fechaDocumento { get; set; }
        public int numeroFolios { get; set; }
        public long tamaño { get; set; }
        public string rutaImagen { get; set; }
        public string estado { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}
