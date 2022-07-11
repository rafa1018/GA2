using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudTerceroBeneficiario
    {
        public Guid SOL_ID_FK { get; set; }
        public int? TER_TIPO_TERCERO_FK { get; set; }
        public int? TID_ID_FK { get; set; }
        public string TER_NUMERO_DOCUMENTO { get; set; }
        public string TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public Guid? ENT_ID_FK { get; set; }
        public int TER_TIPO_CUENTA { get; set; }
        public string TER_NUMERO_CUENTA { get; set; }
        public decimal? TER_VALOR_RETIRAR { get; set; }
        public Guid CREATEDO_POR { get; set; }

        // campos adicionales
        public Guid TER_ID { get; set; }
    }
}
