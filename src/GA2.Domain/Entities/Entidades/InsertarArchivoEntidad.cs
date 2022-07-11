using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class InsertarArchivoEntidad
    {
        public Guid ENE_ARCHIVOS_ID { get; set; }
        public string ENE_NOMBRE_ARCHIVO { get; set; }
        public string? ENE_RUTA_STORAGE { get; set; }
        public string ENE_EXTENSION { get; set; }
        public DateTime ENE_FECHA_CARGUE { get; set; }
        public Guid ENE_ID { get; set; }
        public Guid ENE_PAM_ID { get; set; }
        public Guid ENE_PAM_CREATEDOPOR { get; set; }
    }
}
