using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Reglas de negocio sobre tareas
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public class Reglas
    {
        public Guid RGL_ID { get; set; }
        public Guid TRA_ID { get; set; }
        public string RGL_NOMBRE { get; set; }
        public bool RGL_CUMPLEREGLA { get; set; }
        public Guid RGL_CREATEDOPOR { get; set; }
        public DateTime RGL_FECHACREACION { get; set; }
        public Guid RGL_MODIFICADOPOR { get; set; }
        public DateTime RGL_FECHAMODIFICACION { get; set; }
    }
}
