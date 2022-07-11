using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudMatricula
    {
        public Guid SOL_ID_FK { get; set; }
        public string MAI_NUMERO_MATRICULA { get; set; }
        public DateTime MAI_FECHA_REGISTRO { get; set; }
        public string MAI_DIRECCION { get; set; }
        public int DPC_ID_FK { get; set; }
        public Guid CREATEDO_POR { get; set; }
        public bool MAI_PRINCIPAL { get; set; }

        // campos adicionales
        public Guid MAI_ID { get; set; }
    }
}
