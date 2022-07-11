using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class PropietarioRespuestaDto
    {
        public string numeroIdentificacion { get; set; }
        public string razonSocial { get; set; }
        public LlaveValorDto tipoIdentificacion { get; set; }
        public List<MatriculaPropietarioDto> matricula { get; set; }
    }
}
