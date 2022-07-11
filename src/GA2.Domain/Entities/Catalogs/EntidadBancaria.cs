using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class EntidadBancaria
    {
        public Guid ENT_ID { get; set; }
        public string ENT_NOMBRE_RAZON_SOCIAL { get; set; }
        public int ENT_CODIGO_BANCO { get; set; }
        public bool ENT_ESTADO { get; set; }
        public Guid ENT_CREATEDOPOR { get; set; }
        public DateTime ENT_FECHACREACION { get; set; }
        public Guid ENT_MODIFICADOPOR { get; set; }
        public DateTime ENT_FECHAMODIFICACION { get; set; }
    }
}
