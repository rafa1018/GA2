using GA2.Transversals.Commons;
using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity Table TYPE_FILE_REPORTED
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>05/03/2021</date>
    public class FileNameReported : BaseEntity
    {
        public string FILE_TIPO { get; set; }
        public string FILE_CATEGORIA { get; set; }
        public int FILE_PERIODOS_APORTES { get; set; }
        public string FILE_UNIDAD_EJECUTORA { get; set; }
        public DateTime FILE_FECHA_ENVIO { get; set; }
    }
}
