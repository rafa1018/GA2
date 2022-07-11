using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class RespuestaConsultarSolicitudCesantias
    {
        public int SOL_NUMERO_SOLICITUD { get; set; }
        public string PCS_DESCRIPCION { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public string CLI_PRIMER_NOMBRE { get; set; }
        public DateTime SOL_FECHA_SOLICITUD { get; set; }
        public decimal SOL_VALOR_A_RETIRAR { get; set; }
        public string TRA_NOMBRE { get; set; }
        public string CVL_DESCRIPCION { get; set; }

        public string CLI_ID { get; set; }
    }
}
