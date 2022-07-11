using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class FormularioCreditoConyugueDto
    {

        public List<TipoIdentificacionDto> TiposIdentificacion { get; set; }
        public List<DepartamentoDto> Departamentos { get; set; }

        public InformacionConyugueDto InformacionConyugue { get; set; }

    }
}
