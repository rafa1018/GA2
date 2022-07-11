using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class EliminarArchivoPorSolicitudDto
    {
        public Guid idArchivo { get; set; }
        public string rutaStorage { get; set; }
    }
}