using System;

namespace GA2.Domain.Entities
{
    public class SolicitudMatriculaPropietario
    {
        public Guid MAI_ID { get; set; }
        public string MAI_NUMERO_MATRICULA { get; set; }
        public bool MAI_PRINCIPAL { get; set; }
        public string PRP_NUMERO_IDENTIFICACION { get; set; }
        public int TID_ID { get; set; }
        public string TID_DESCRIPCION { get; set; }
        public string PRP_NOMBRE_RAZON_SOCIAL { get; set; }
    }
}
