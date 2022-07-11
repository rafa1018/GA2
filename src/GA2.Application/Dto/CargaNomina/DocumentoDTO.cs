using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// DTO documento carga de archivo
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class DocumentoDto
    {
        public int DocumentoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicialDocumento { get; set; }
        public int EstadoDocumento { get; set; }
        public int CausalEstadoDocumento { get; set; }
        public int UnidadEjecutora { get; set; }
        public DateTime FechaFinalDocumento { get; set; }
        public int AnulaId { get; set; }
        public string Alerta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid CreadoPor { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
