using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class MatriculaRespuestaDto
    {
        public Guid id { get; set; }
        public string numeroMatricula { get; set; }
        public bool esPrincipal { get; set; }
        public string direccion { get; set; }
        public int ciudadId { get; set; }
        public LlaveValorDto departamento { get; set; }
        public LlaveValorDto ciudad { get; set; }
        public bool bloqueo { get; set; }
    }
}
