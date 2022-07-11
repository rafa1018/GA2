using System;

namespace GA2.Domain.Entities
{
    public class ObtenerTramiteSolicitud
    {
        public Guid SOL_ID { get; set; }
        public Guid SLT_ID { get; set; }
        public Guid ULTIMO_SLT_ID { get; set; }
        public int CTA_ID { get; set; }
        public Guid TIM_ID { get; set; }
        public Guid TPS_SUB_ID { get; set; }
        public int SOL_ESTADO_SOLICITUD { get; set; }
        public int CLI_ID { get; set; }
        public DateTime SOL_FECHA_SOLICITUD { get; set; }
        public bool SOL_ESTADO { get; set; }
        public int SLT_ESTADO_SOLICITUD { get; set; }
        public string VOLVER_PANTALLA { get; set; }
        public string TPS_SUB_DESCRIPCION { get; set; }
        public string TIM_DESCRIPCION { get; set; }
        public string PCS_DESCRIPCION { get; set; }
        public decimal SOL_VALOR_A_RETIRAR { get; set; }
        public string PESTANAS { get; set; }
    }
}
