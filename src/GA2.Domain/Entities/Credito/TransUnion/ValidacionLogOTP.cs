﻿using System;

namespace GA2.Domain.Entities
{
    public class VLL_VALIDACION_LOG_OTP
    {
        public Guid VLL_ID { get; set; }
        public Guid VLI_ID { get; set; }
        public string VLL_CODIGO_OTP { get; set; }
        public string VLL_ID_APICACION { get; set; }
        public string VLL_ESTADO_VALIDACION { get; set; }
        public DateTime VLL_FECHA_ACTUALIZA { get; set; }
    }
}
