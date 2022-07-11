using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudTerceroTenedorAcciones
    {
        public Guid SOL_ID_FK { get; set; }
        public int? TER_TIPO_TERCERO_FK { get; set; }
        public string TID_ID_FK { get; set; }
        public string TER_NUMERO_DOCUMENTO { get; set; }
        public string TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public string TER_DIRECCION { get; set; }
        public string DPC_ID_FK { get; set; }
        public string TER_CORREO_ELECTRONICO { get; set; }
        public string TER_TELEFONO { get; set; }
        public Guid TER_CREATEDOPOR { get; set; }
        public string TER_EMISOR_NOMBRE_RAZON_SOCIAL { get; set; }

        // campos adicionales
        public Guid TER_ID { get; set; }
    }
}
