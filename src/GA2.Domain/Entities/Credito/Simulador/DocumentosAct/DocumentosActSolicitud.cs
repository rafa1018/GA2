using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class DocumentosActSolicitud
    {
        [Key]
        public Guid SOC_ID { get; set; }
        public int AFL_ID { get; set; }
        public int TCR_ID { get; set; }
    }
}
