using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ConsultarArchivoPorEntidadDto
    {
        public Guid IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public string? RutaStorage { get; set; }
        public string Extension { get; set; }
        public string TipoArchivo { get; set; }
        public int Orden { get; set; }
    }
}
