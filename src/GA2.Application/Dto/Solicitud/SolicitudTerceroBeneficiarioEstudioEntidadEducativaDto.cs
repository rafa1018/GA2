using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudTerceroBeneficiarioEstudioEntidadEducativaDto
    {
        public string TipoDocEstudio { get; set; }
        public LlaveValorStringDto TipoDocEstudioObj { get; set; }
        public string NumDocEstudio { get; set; }
        public string RazonsocialEstudio { get; set; }
        public string ParentescoEstudio { get; set; }
        public LlaveValorStringDto ParentescoEstudioObj { get; set; }

        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public Guid IdEntidad { get; set; }
        public Guid IdNivel { get; set; }
        public string ReciboPago { get; set; }
        public DateTime Fechalimite { get; set; }
    }
}
