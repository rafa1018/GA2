using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class VerificacionTerceroRequest
    {
        public string Pe_Origen { get; set; }
        public string Pe_Dato { get; set; }
        public string Pe_TipoVerificacion { get; set; }
        public string Pe_Porcentaje { get; set; }
    }
}
