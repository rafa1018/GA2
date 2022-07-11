using GA2.Domain.Entities;
using System;
using System.IO;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Anadido Dto
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>13/08/2021</date>
    public  class AnadidosDto
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
}
