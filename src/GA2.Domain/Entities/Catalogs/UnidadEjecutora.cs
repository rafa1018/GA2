using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class UnidadEjecutora
    {
        [Key]
        public int UEJ_ID { get; set; }
        public int TID_ID { get; set; }
        public string UEJ_IDENTIFICACION { get; set; }
        public string UEJ_NOMBRE { get; set; }
        public string UEJ_SIGLA { get; set; }
        public DateTime UEJ_FECHA { get; set; }
        public int FRZ_ID { get; set; }
        public int UEJ_CODIGO { get; set; }
        public decimal UEJ_TASA_APORTE { get; set; }
        public int UEJ_AREA_NEGOCIO { get; set; }
        public int FRM_ID { get; set; }
        public bool UEJ_AVAL { get; set; }
    }
}
