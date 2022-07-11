using System;

namespace GA2.Application.Dto
{
    public class AportesClienteDto
    {
        public int CLI_ID { get; set; }
        public int CGT_ID { get; set; }
        public int APC_CUOTAS_ACUMULADAS { get; set; }
        public DateTime APC_FECHA_ULTIMA_COUTA { get; set; }
        public DateTime APC_FECHA_PRIMERA_CUOTA { get; set; }
    }
}