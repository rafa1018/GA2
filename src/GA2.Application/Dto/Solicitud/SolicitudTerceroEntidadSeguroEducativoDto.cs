using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudTerceroEntidadSeguroEducativoDto
    {
        public int tipoDocId { get; set; }
        public string numDoc { get; set; }
        public string razonSocialAseguradora { get; set; }
        public Guid entidadSeguroEducativoId { get; set; }
        public string numeroPoliza { get; set; }
    }
}
