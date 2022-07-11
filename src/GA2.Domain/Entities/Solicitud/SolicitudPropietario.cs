using System;

namespace GA2.Domain.Entities
{
    public class SolicitudPropietario
    {
        public Guid SOL_ID_FK { get; set; }
        public int TID_ID_FK { get; set; }
        public string PRP_NUMERO_IDENTIFICACION { get; set; }
        public string PRP_NOMBRE_RAZON_SOCIAL { get; set; }
        public Guid CREATEDO_POR { get; set; }
        public String TID_DESCRIPCION { get; set; }

        // campos adicionales
        public Guid PRP_ID { get; set; }
        public bool PRP_ESTADO { get; set; }

    }
}
