using System;

namespace GA2.Domain.Entities
{
    public class SolicitudComite
    {
        public Guid? SOC_ID { get; set; }
        public int SOC_NUMERO_SOLICITUD { get; set; }
        public int TCR_ID { get; set; }
        public string TIPO_CREDITO { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public int COC_ID { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string RESULTADO { get; set; }
        public string APROBADA { get; set; }
        public string RECHAZADA { get; set; }
        public string PROCESADA { get; set; }
        public Guid USUARIO_CREACION { get; set; }
        public DateTime? FECHA_CREACION { get; set; }
        public int VALOR_CREDITO { get; set; }
        public int PLAZO_CREDITO { get; set; }
        public decimal TEA_CREDITO { get; set; }
        public decimal VALOR_CUIOTA { get; set; }

    }
}
