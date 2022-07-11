using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Encabezado de archivo dto
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>22/05/2021</date>
    public class EncabezadoArchivoDto
    {
        public int CONSECUTIVE { get; set; }
        public int FILE_TIPO { get; set; }
        public string NOMBRE_NOMINA_UNIDAD_EJECUTORA { get; set; }
        public int ID_UNIDAD_EJECUTORA { get; set; }
        public DateTime FECHA_APORTES { get; set; }
    }
}