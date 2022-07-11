using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity de mensaje
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>28/05/2021</date>
    /// </summary>
    public class Mensaje
    {
        public Guid MSJ_ID { get; set; }
        public string MSJ_CODIGO { get; set; }
        public string MSJ_MENSAJE { get; set; }
        public string MSJ_TIPO { get; set; }
        public Guid MSJ_CREADO_POR { get; set; }
        public Guid MSJ_MODIFICADO_POR { get; set; }
        public DateTime MSJ_FECHA_CREACION { get; set; }
        public DateTime MSJ_FECHA_MODIFICACION { get; set; }
        public bool MSJ_ESTADO { get; set; }

    }
}
