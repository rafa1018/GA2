using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class Auditoria
    {
        public Guid ID_AUDITORIA { get; set; }
        public string NOMBRE_TABLA { get; set; }
        public string TIPO_ACCION { get; set; }
        public string NOMBRE_COLUMNA { get; set; }
        public string VALOR_ANTERIOR { get; set; }
        public string VALOR_NUEVO { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public Guid USR_ID { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public Guid AGRUPADOR { get; set; }

    }

    public class ConsultaAuditoria
    {
        public string? AUR_NOM_TABLE { get; set; }
        public DateTime? AUR_FECHA_FILTRO_INICIO { get; set; }
        public DateTime? AUR_FECHA_FILTRO_FIN { get; set; }
        public Guid? AUR_USR_ID { get; set; }
        public string? AUR_AGRUPADOR { get; set; }
        public bool AUR_VER_DETALLE { get; set; }
        public int PAGENUM { get; set; }
        public int PAGESIZE { get; set; }

    }


    public class TablasAuditoria
    {
        public string NOMBRE_TABLA { get; set; }
    }


}
