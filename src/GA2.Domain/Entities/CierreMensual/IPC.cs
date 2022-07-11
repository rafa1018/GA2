using System;

namespace GA2.Domain.Entities
{
    public class IPC
    {
        public int ID { get; set; }
        public int ANIO { get; set; }
        public int MES { get; set; }
        public float VALOR_IPC { get; set; }
        public DateTime FECHA_ACTUALIZACION { get; set; }

    }
}
