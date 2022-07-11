using System;

namespace GA2.Domain.Entities
{
    public class ClasificacionArchivo
    {
        public int CLA_ID { get; set; }
        public string CLA_CODIGO { get; set; }
        public string CLA_DESCRIPCION { get; set; }
        public DateTime CLA_FECHA_CREACION { get; set; }
        public Guid CLA_CREADO_POR { get; set; }
        public DateTime CLA_FECHA_MODIFICACION { get; set; }
        public Guid CLA_MODIFICADO_POR { get; set; }
        public bool CLA_ESTADO { get; set; }
    }
}
