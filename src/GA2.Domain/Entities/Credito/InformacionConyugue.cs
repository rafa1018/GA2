using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class InformacionConyugue
    {

        public Guid SOY_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int TID_ID { get; set; }
        public string SOY_NUMERO_DOCUMENTO { get; set; }
        public DateTime SOY_FECHA_EXPEDICION { get; set; }
        public int DPD_ID_EXP { get; set; }
        public int DPC_ID_EXP { get; set; }
        public string SOY_PRIMER_APELLIDO { get; set; }
        public string SOY_SEGUNDO_APELLIDO { get; set; }
        public string SOY_PRIMER_NOMBRE { get; set; }
        public string SOY_SEGUNDO_NOMBRE { get; set; }
        public DateTime SOY_FECHA_NACIMIENTO { get; set; }
        public int DPD_ID_NACIMIENTO { get; set; }
        public int DPC_ID_NACIMIENTO { get; set; }
        public string SOY_CELULAR { get; set; }
        public string SOY_CORREO_PERSONAL { get; set; }
        public string SOY_ACTIVIDAD_LABORAL { get; set; }
        public string SOY_OTRO_ACTIVIDAD { get; set; }
        public string SOY_EMPRESA_LABORA { get; set; }
        public Guid SOY_CREADO_POR { get; set; }
        public DateTime SOY_FECHA_CREACION { get; set; }
        public Guid SOY_ACTUALIZADO_POR { get; set; }
        public DateTime SOY_FECHA_ACTUALIZA { get; set; }

    }
}
