using System;

namespace GA2.Domain.Entities
{
    public class ClienteCedula
    {
        #region Cliente
        public int CLI_ID { get; set; }
        public int TPA_ID { get; set; }
        public int TID_ID { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public DateTime CLI_FECHA_EXPEDICION { get; set; }
        public int DPC_ID_IDENTIFICACION_EXPEDIDA { get; set; }
        public int DPD_ID_IDENTIFICACION_EXPEDIDA { get; set; }
        public string CLI_PRIMER_NOMBRE { get; set; }
        public string CLI_SEGUNDO_NOMBRE { get; set; }
        public string CLI_PRIMER_APELLIDO { get; set; }
        public string CLI_SEGUNDO_APELLIDO { get; set; }
        public DateTime CLI_FECHA_NACIMIENTO { get; set; }
        public int DPD_ID { get; set; }
        public int DPC_ID { get; set; }
        public string CAT_SEXO { get; set; }
        public string CAT_ESTADO_CIVIL { get; set; }
        public int CLI_PROFESION { get; set; }
        public string CLI_UNIDAD { get; set; }
        public int CTG_ID { get; set; }
        public int FRZ_ID { get; set; }
        public int GRD_ID { get; set; }
        #endregion

    }
}
