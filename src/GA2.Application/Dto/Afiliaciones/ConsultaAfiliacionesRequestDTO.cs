using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ConsultaAfiliacionesRequestDTO
    {
        public int tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public int tipoafiliacion { get; set; }
    }
}
