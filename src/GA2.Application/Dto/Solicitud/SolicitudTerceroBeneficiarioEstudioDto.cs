using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudTerceroBeneficiarioEstudioDto
    {
        public string tipoDocEstudio { get; set; }
        public LlaveValorStringDto tipoDocEstudioObj { get; set; }
        public string numDocEstudio { get; set; }
        public string razonsocialEstudio { get; set; }
        public string parentescoEstudio { get; set; }
        public LlaveValorStringDto parentescoEstudioObj { get; set; }
    }
}
