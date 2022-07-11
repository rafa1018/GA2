using System;
using System.ComponentModel;
using System.IO;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Añadidos de documentos, anotacioens, descripciones
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public class Anadidos
    {
        public Guid TRA_ID { get; set; }
        public Guid AND_ID { get; set; }
        public string AND_NOMBREANADIDO { get; set; }
        public Stream AND_FILE { get; set; }
        public ANADIDO_TIPO AND_TIPO { get; set; }
        public Guid AND_CREATEDOPOR { get; set; }
        public DateTime AND_FECHACREACION { get; set; }
        public Guid AND_MODIFICADOPOR { get; set; }
        public DateTime AND_FECHAMODIFICACION { get; set; }
    }


    public enum ANADIDO_TIPO
    {
        [Description("Documento")]
        DOCUMENTO,
        [Description("Anotacion")]
        ANOTACION,
    }

}
