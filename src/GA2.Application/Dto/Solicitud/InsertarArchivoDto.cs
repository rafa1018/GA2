using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class InsertarArchivoDto
    {
        public string nombreArchivo { get; set; }
        public string? ruta { get; set; }
        public string extension { get; set; }
        public DateTime fechaCargue { get; set; }
    }
}
