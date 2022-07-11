using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class RespuestaTerceroVendedor
    {
        public Guid TER_ID { get; set; }
        public int TID_ID_FK { get; set; }
        public string TID_DESCRIPCION { get; set; }
        public string TER_NUMERO_DOCUMENTO { get; set; }
        public string TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public string TER_DIRECCION { get; set; }
        public int DPD_ID { get; set; }
        public string DPD_NOMBRE { get; set; }
        public int DPC_ID { get; set; }
        public string DPC_NOMBRE { get; set; }
        public string TER_CORREO_ELECTRONICO { get; set; }
        public string TER_TELEFONO { get; set; }
    }
}
