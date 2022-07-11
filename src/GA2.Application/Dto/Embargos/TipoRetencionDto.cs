using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TipoRetencionDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
