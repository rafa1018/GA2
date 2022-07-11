using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities.Credito.Simulador
{ 
    public class SimulacionSolicitud
    {
        public Guid SLS_ID { get; set; }
        public DateTime SLS_FECHA_SOLICITUD { get; set; }
        public int TCR_ID { get; set; }
        public Int64 SLS_NUMERO_PREAPROBADO { get; set; }
        public int SLS_PROBLEMA_EMAIL { get; set; }
        public int SLS_ENVIO_NOTIFICACION { get; set; }
        public string SLS_RUTA_PDF_RESUMEN { get; set; }
        public string SLS_ESTADO { get; set; }
        public Guid SLS_USUARIO_ACTUALIZA { get; set; }
        public DateTime SLS_FECHA_ACTUALIZA { get; set; }
        public string VALOR_PRESTAMO { get; set; }
        public string VALOR_VIVIENDA { get; set; }
        public string TIPO_VIVIENDA { get; set; }
        public string VIVIENDA_VIS { get; set; }

    }
}

