using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de notificacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>05/05/2021</date>
    /// </summary>
    public class Notificacion
    {
        public Guid MOD_N_ID { get; set; }
        public string MOD_N_MENSAJE { get; set; }
        public Guid MOD_N_RECEPTOR { get; set; }
        public string MOD_N_TIPO { get; set; }
        public bool MOD_N_VISTO { get; set; }
        public Guid MOD_N_EMISOR { get; set; }
        public DateTime MOD_N_FECHA_CREACION { get; set; }
        public bool MOD_N_ESTADO { get; set; }

    }
}
