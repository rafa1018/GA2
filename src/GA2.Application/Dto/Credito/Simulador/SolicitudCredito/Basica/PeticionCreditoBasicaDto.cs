using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class PeticionCreditoBasicaDto
    {
        [Key]
        public string SOB_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int IND { get; set; }
    }
}
