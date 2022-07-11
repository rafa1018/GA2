using System;

namespace GA2.Application.Dto
{
    public class PeticionFlujoDocumentosDto
    {
        public Guid SOC_ID { get; set; }
        public int TCR_ID { get; set; }
        public int ORDEN { get; set; }
        public string PRINCIPAL { get; set; }
        public int AFL_ID { get; set; }
    }
}
