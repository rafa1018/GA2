using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DocumentoTipoDto
    {
        public int IdDocumento { get; set; }
        public string AbreviaturaDocumento { get; set; }
        public string DescripcionDocumento { get; set; }
        public bool EstadoDocumento { get; set; }
    }
}
