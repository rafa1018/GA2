using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto.Catalogs
{
    public class CausalEstadoCuentaDto
    {
        public int CausalEstadoId { get; set; }
        public int EstadoCuentaId { get; set; }
        public string CausalCuentaDescripcion { get; set; }
        public bool CausalActiva { get; set; }
    }
}
