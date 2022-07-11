using System;

namespace GA2.Domain.Entities
{
    public class RequestSolicCreditoInfTecInm
    {
        public string STI_ID { get; set; }
        public string SIT_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int IND { get; set; }
    }
}
