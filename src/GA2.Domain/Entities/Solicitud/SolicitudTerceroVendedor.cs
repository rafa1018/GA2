using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudTerceroVendedor
    {
        public Guid SOL_ID_FK { get; set; }
        public int? TER_TIPO_TERCERO_FK { get; set; }
        public int TID_ID_FK { get; set; }
        public string TER_NUMERO_DOCUMENTO { get; set; }
        public string TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public string TER_DIRECCION { get; set; }
        public int DPC_ID_FK { get; set; }
        public string TER_CORREO_ELECTRONICO { get; set; }
        public string TER_TELEFONO { get; set; }
        public Guid CREATEDO_POR { get; set; }

        // campos adicionales
        public Guid TER_ID { get; set; }
    }
}
