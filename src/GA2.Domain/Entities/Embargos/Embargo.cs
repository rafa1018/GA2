using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class Embargo
    {
        public Guid EBA_ID { get; set; }
        public string EBA_RADICADO_WORK_MANAGER { get; set; }
        public DateTime EBA_FECHA_RADICADO_WORK_MANAGER { get; set; }
        public string EBA_RADICADO_JUZGADO { get; set; }
        public DateTime EBA_FECHA_RADICADO_JUZGADO { get; set; }
        public string EBA_EMAIL_RESPUESTA { get; set; }
        public string EBA_DIRECCION_RESPUESTA { get; set; }
        public string EBA_NOMBRE_DEMANDANTE { get; set; }
        public string EBA_NOMBRE_DEMANDADO { get; set; }
        public string EBA_EXPEDIENTE_BANCO_AGRARIO { get; set; }
        public string EBA_REMANENTE { get; set; }
        public string EBA_OBSERVACIONES { get; set; }
        public string EBA_RESPUESTA { get; set; }
        public double EBA_VALOR { get; set; }
        public int CLI_ID { get; set; }
        public Guid EMB_ID_JUZGADO { get; set; }
        public Guid TPE_ID { get; set; }
        public Guid TIE_ID { get; set; }
        public DateTime EBA_FECHA_REGISTRO { get; set; }
        public DateTime EBA_FECHA_ACTUALIZACION { get; set; }
        public Guid EBA_CREADOPOR { get; set; }
        public Guid EBA_ACTUALIZADOPOR { get; set; }

        public string JUZGADO { get; set; }
        public string TIPO_PROCESO { get; set; }
        public string TIPO_EMBARGO { get; set; }



    }


    
}
