using System;

namespace GA2.Application.Dto
{
    public class ParametrizacionArchivoModalidadDto
    {
        public Guid parametrizacionId { get; set; }
        public string nombreArchivo { get; set; }
        public string descripcionArchivo { get; set; }
        public Boolean estadoRequerido { get; set; }
        public Boolean estadoActivo { get; set; }
        public int ordenamiento { get; set; }
    }
}
