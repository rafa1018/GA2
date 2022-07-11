using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Error Response Entity
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>08/03/2021</date>
    /// </summary>
    public class ERRORRESPONSE
    {
        public ERRORRESPONSE() => LOGERRORID = Guid.NewGuid();
        public Guid LOGERRORID { get; set; }
        public Guid CLIENTID { get; set; }
        public string MESSAGE { get; set; }
        public string CONTROLLERNAME { get; set; }
        public string ACTIONNAME { get; set; }
        public string STACKTRACE { get; set; }
        public int ERRORCODE { get; set; }
        public string REQUESTIP { get; set; }
        public DateTime LOGDATE { get; set; } = DateTime.Now;
    }
}
