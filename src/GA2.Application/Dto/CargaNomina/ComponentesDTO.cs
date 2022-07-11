using System.Collections.Generic;

namespace GA2.Application.Dto
{
    /// <summary>
    /// DTO componentes que se extraen desde carga nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class ComponentesDTO
    {
        public DocumentoDto DOCUMENTO { get; set; }
        public NombreArchivoDto FILENAME { get; set; }
        public EncabezadoArchivoDto HEADER { get; set; }
        public IEnumerable<CuerpoArchivoDto> BODY { get; set; }
        public FinDeArchivoDto END { get; set; }
    }
}
