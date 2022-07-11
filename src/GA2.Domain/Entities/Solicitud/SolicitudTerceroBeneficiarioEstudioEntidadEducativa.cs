using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudTerceroBeneficiarioEstudioEntidadEducativa
    {
        public Guid SOL_ID_FK { get; set; }
        public int? TER_TIPO_TERCERO_FK { get; set; }
        public string TID_ID_FK { get; set; }
        public string TER_NUMERO_DOCUMENTO { get; set; }
        public string TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public string TER_PARENTESCO { get; set; }

        public Guid ENE_ID { get; set; }
        public string ENE_NIT { get; set; }
        public string ENE_NOMBRE_RAZON_SOCIAL { get; set; }
        public Guid PRN_ID_FK { get; set; }
        public string TER_NUM_RECIBO_PAGO { get; set; }
        public decimal SOL_VALOR_A_RETIRAR { get; set; }
        public DateTime TER_FECHA_LIMITE_PAGO { get; set; }
        public Guid ENE_CREATEDOPOR { get; set; }

        // campos adicionales
        public Guid TER_ID { get; set; }
    }
}
