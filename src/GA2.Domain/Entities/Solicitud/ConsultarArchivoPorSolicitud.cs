using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ConsultarArchivoPorSolicitud
    {
        public Guid AST_ID { get; set; }
        public string AST_NOMBRE_ARCHIVO { get; set; }
        public string AST_RUTA_STORAGE { get; set; }
        public string AST_EXTENSION { get; set; }
        public string PAM_NOMBRE_ARCHIVO { get; set; }
        public int PAM_ORDEN { get; set; }
    }
}
