using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class InsertarArchivo
    {
        public Guid AST_ID { get; set; }
        public string AST_NOMBRE_ARCHIVO { get; set; }
        public string? AST_RUTA_STORAGE { get; set; }
        public string AST_EXTENSION { get; set; }
        public DateTime AST_FECHA_CARGUE { get; set; }
        public Guid SOL_ID_FK { get; set; }
        public Guid PAM_ID_FK { get; set; }
        public Guid AST_CREATEDOPOR { get; set; }
    }
}
