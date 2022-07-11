using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    public class CargarDocumentosSolicitudDto
    {
        public Guid archivoParametrizadoId { get; set; }
        public List<IFormFile>? archivosCargados { get; set; }
    }
}
