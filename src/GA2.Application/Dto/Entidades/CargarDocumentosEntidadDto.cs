using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    public class CargarDocumentosEntidadDto
    {
        public Guid ArchivoParametrizadoId { get; set; }
        public List<IFormFile>? ArchivosCargados { get; set; }
    }
}
