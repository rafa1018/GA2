using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TipoInconsistenciaDto
    {
        public int GrupoInconsistencia { get; set; }
        public Guid IdTipoInconsistencia { get; set; }
        public string DescripcionInconsistencia { get; set; }
    }
}
