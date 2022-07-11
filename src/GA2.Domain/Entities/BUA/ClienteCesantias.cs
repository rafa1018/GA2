namespace GA2.Domain.Entities
{
    /// <summary>
    /// Cliente Cesantias
    /// <author>Erwin Pantoja España</author>
    /// <date>07/10/2021</date>
    /// </summary>
    public class ClienteCesantias
    {
        #region Cliente
        public int CLI_ID { get; set; }
        public int TPA_ID { get; set; }
        public int TID_ID { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public string CLI_PRIMER_NOMBRE { get; set; }
        public string CLI_SEGUNDO_NOMBRE { get; set; }
        public string CLI_PRIMER_APELLIDO { get; set; }
        public string CLI_SEGUNDO_APELLIDO { get; set; }
        public string CORREO_PERSONAL { get; set; }
        public string NO_CELULAR { get; set; }
        public string TELEFONO_RESIDENCIA { get; set; }
        public string DRC_DIRECCION { get; set; }
        #endregion

    }
}
