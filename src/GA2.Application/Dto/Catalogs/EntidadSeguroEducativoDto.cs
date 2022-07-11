using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class EntidadSeguroEducativoDto
    {
        public Guid idEntidadSeguroEducativo { get; set; }
        public int tipoIdentificacion { get; set; }
        public string numeroIdentificacion { get; set; }
        public string nombreRazonSocial { get; set; }
        
    }
}