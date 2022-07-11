using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class Desembargo
    {
        public Guid DES_ID { get; set; }
        public Guid ECC_ID { get; set; }
        public DateTime DES_FECHA_REGISTRO { get; set; }
        public bool DES_ESTADO { get; set; }

    }

    public class ObtenerDesembargo
    {
        public Guid DES_ID { get; set; }
        public string EBA_RADICADO_WORK_MANAGER { get; set; }
        public string EBA_RADICADO_JUZGADO { get; set; }
        public string EBA_NOMBRE_DEMANDANTE { get; set; }
        public string EBA_NOMBRE_DEMANDADO { get; set; }
        public string EBA_EXPEDIENTE_BANCO_AGRARIO { get; set; }
        public int CLI_ID { get; set; }
        public string JUZGADO { get; set; }
        public string TIPO_PROCESO { get; set; }
        public string TIPO_EMBARGO { get; set; }
        public int ECC_VALOR { get; set; }
        public int CTA_ID { get; set; }
        public string TIPO_RETENCION { get; set; }

    }
}
