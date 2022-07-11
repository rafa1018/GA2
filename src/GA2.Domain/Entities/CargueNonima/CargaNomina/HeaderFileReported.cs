using GA2.Transversals.Commons;
using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity Header Table
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>05/03/2021</date>
    public class HeaderFileReported : BaseEntity
    {
        public int CONSECUTIVE { get; set; }
        public int FILE_TIPO { get; set; }
        public string NOMBRE_NOMINA_UNIDAD_EJECUTORA { get; set; }
        public int ID_UNIDAD_EJECUTORA { get; set; }
        public DateTime FECHA_APORTES { get; set; }
    }
}
