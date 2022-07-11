using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de Validación Identidad Cliente
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>26/03/2021</date>
    public class ValidacionIdentidad
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
        public string VLI_ID_APLICACION { get; set; }
        public string VLI_CODIGO_OTP { get; set; }
        public string VLI_DELAY { get; set; }
        public int VLI_PASO_VALIDACION { get; set; }
        public string VLI_USUARIO_ACTUALIZA { get; set; }
        public DateTime VLI_FECHA_ACTUALIZA { get; set; }
        public string VALOR_PRESTAMO { get; set; }
        public string VALOR_VIVIENDA { get; set; }
        public string TIPO_VIVIENDA { get; set; }
        public string VIVIENDA_VIS { get; set; }


    }
}
