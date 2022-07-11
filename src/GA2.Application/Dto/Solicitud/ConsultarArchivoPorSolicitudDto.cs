using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ConsultarArchivoPorSolicitudDto
    {
        public Guid idArchivo { get; set; }
        public string nombreArchivo { get; set; }
        public string? rutaStorage { get; set; }
        public string extension { get; set; }
        public string tipoArchivo { get; set; }
        public int orden { get; set; }
    }
}
