using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudMatriculaDto
    {
        public string NumeroMatricula { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }
        public bool EsPrincipal { get; set; }

        //campos adicionales
        public Guid id { get; set; }
    }

}
