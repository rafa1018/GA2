using System;

namespace GA2.Application.Dto
{
    public class DocumentosPorSubModalidadDto
    {
        public Guid idArchivo { get; set; }
        public string nombreArchivo { get; set; }
        public string descripcionArchivo { get; set; }
        public bool esRequerido { get; set; }
        public int ordenArchivo { get; set; }
        public bool esMultipleArchivo { get; set; }
        public string formatoArchivo { get; set; }
    }
}
