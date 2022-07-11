using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class PeticionFlujoDocumentos
    {
        [Key]
        public Guid SOC_ID { get; set; }
        public int TCR_ID { get; set; }
        public int ORDEN { get; set; }
        public string PRINCIPAL { get; set; }
        public string AFL_ID { get; set; }
    }
}
