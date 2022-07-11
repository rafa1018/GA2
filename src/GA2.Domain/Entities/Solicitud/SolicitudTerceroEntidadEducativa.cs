using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudTerceroEntidadEducativa
    {
        public Guid ENE_ID { get; set; }
        public string ENE_NIT { get; set; }
        public string ENE_NOMBRE_RAZON_SOCIAL { get; set; }
        public Guid PRN_ID_FK { get; set; }
        public string TER_NUM_RECIBO_PAGO { get; set; }
        public DateTime TER_FECHA_LIMITE_PAGO { get; set; }
        public Guid ENE_CREATEDOPOR { get; set; }
        public int? TER_TIPO_TERCERO_FK { get; set; }
        public Guid SOL_ID_FK { get; set; }
        public int TID_ID_FK { get; set; }
    }
}