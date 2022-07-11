using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class RespuestaPropietario
    {
        public Guid SOL_ID_FK { get; set; }
        public int TID_ID_FK { get; set; }
        public string PRP_NUMERO_IDENTIFICACION { get; set; }
        public string PRP_NOMBRE_RAZON_SOCIAL { get; set; }
        public Guid CREATEDO_POR { get; set; }
        public String TID_DESCRIPCION { get; set; }
        public Guid PRP_ID { get; set; }
        public bool PRP_ESTADO { get; set; }
        public Guid MAI_ID { get; set; }
        public string MAI_NUMERO_MATRICULA { get; set; }
        public bool MAI_PRINCIPAL { get; set; }
    }
}
