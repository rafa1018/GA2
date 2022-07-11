using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Nombre de archivo reportado
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>22/05/2021</date>
    public class NombreArchivoDto
    {
        public string FILE_TIPO { get; set; }
        public string FILE_CATEGORIA { get; set; }
        public DateTime FILE_PERIODOS_APORTES { get; set; }
        public int FILE_UNIDAD_EJECUTORA { get; set; }
        public DateTime FILE_FECHA_ENVIO { get; set; }
    }
}