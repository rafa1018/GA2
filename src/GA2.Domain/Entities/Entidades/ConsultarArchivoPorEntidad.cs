using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ConsultarArchivoPorEntidad
    {
        public Guid ENE_ARCHIVOS_ID { get; set; }
        public string ENE_NOMBRE_ARCHIVO { get; set; }
        public string ENE_RUTA_STORAGE { get; set; }
        public string ENE_EXTENSION { get; set; }
        public int ENE_PAM_ORDEN { get; set; }
    }
}
