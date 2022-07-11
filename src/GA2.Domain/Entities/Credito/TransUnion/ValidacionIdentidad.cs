using System;

namespace GA2.Domain.Entities
{
    public class VLI_VALIDACION_IDENTIDAD
    {
        public Guid VLI_ID { get; set; }
        public int TID_ID { get; set; }
        public DateTime VLI_FECHA_EXPEDICION { get; set; }
        public string VLI_NUMERO_DOCUMENTO { get; set; }
        public string VLI_NUMERO_CELULAR { get; set; }
        public int VLI_ACEPTA_HABEAS { get; set; }
        public int VLI_ACEPTA_TERMINOS { get; set; }
        public DateTime VLI_FECHA_VALIDA_IDEN { get; set; }
        public DateTime VLI_FECHA_VALIDA_OTP { get; set; }
        public string VLI_CODIGO_OTP { get; set; }
        public int VLI_PASO_VALIDACION { get; set; }

    }
}
