using System;

namespace GA2.Domain.Entities
{
    public class RequestSolicCreditoInfJurInm
    {
        public string SJI_ID { get; set; }
        public string SIJ_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int IND { get; set; }
    }
}
