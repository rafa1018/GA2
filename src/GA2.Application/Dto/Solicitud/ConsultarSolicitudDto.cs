using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ConsultarSolicitudDto
    {
        public Guid tipoSubModalidadId { get; set; }
        public string identificacion { get; set; }
        public int tipoIdentificacion { get; set; }
    }
}
