using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Restricciones Dto
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>13/08/2021</date>
    public class RestriccionesDto
    {
        public Guid TRA_ID { get; set; }
        public Guid RTC_ID { get; set; }
        public string RTC_NOMBRE { get; set; }
        public Guid TRA_ID_RESTRICCION { get; set; }
        public Guid RTC_CREATEDOPOR { get; set; }
        public DateTime RTC_FECHACREACION { get; set; }
        public Guid RTC_MODIFICADOPOR { get; set; }
        public DateTime RTC_FECHAMODIFICACION { get; set; }
    }
}
