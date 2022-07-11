using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SocSolicitudInfobasica
    {
        public Guid SOB_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int TID_ID { get; set; }
        public string SOB_NUMERO_DOCUMENTO { get; set; }
        public DateTime SOB_FECHA_EXPEDICION { get; set; }
        public int DPD_ID_EXP { get; set; }
        public int DPC_ID_EXP { get; set; }
        public string SOB_PRIMER_APELLIDO { get; set; }
        public string SOB_SEGUNDO_APELLIDO { get; set; }
        public string SOB_PRIMER_NOMBRE { get; set; }
        public string SOB_SEGUNDO_NOMBRE { get; set; }
        public DateTime SOB_FECHA_NACIMIENTO { get; set; }
        public int DPD_ID_NACIMIENTO { get; set; }
        public int DPC_ID_NACIMIENTO { get; set; }
        public string SOB_SEXO { get; set; }
        public string SOB_ESTADO_CIVIL { get; set; }
        public string SOB_NIVEL_EDUCACION { get; set; }
        public int FRZ_ID { get; set; }
        public int CTG_ID { get; set; }
        public int GRD_ID { get; set; }
        public int DPD_ID_RESIDENCIA { get; set; }
        public int DPC_ID_RESIDENCIA { get; set; }
        public string SOB_DIRECCION_RESIDENCIA { get; set; }
        public string SOB_CORREO_PERSONAL { get; set; }
        public string SOB_TELEFONO_RESIDENCIA { get; set; }
        public string SOB_CELULAR { get; set; }
        public int DPD_ID_OFICINA { get; set; }
        public int DPC_ID_OFICINA { get; set; }
        public string SOB_DIRECCION_OFICINA { get; set; }
        public string SOB_CORREO_INSTITUCIONAL { get; set; }
        public string SOB_TELEFONO_OFICINA { get; set; }
        public int ACC_ID { get; set; }
        public int PRF_ID { get; set; }
        public string SOB_TIENE_TRANSACCION_ME { get; set; }
        public string SOB_TIPO_TRANSACCION_ME { get; set; }
        public string SOB_TIPO_PRODUCTO_ME { get; set; }
        public string SOB_BANCO_TRANSACCION_ME { get; set; }
        public string SOB_NUMERO_PRODUCTO_ME { get; set; }
        public decimal SOB_SALDO_PROMEDIO_CUENTAS_ME { get; set; }
        public string SOB_MONEDA_TRANSACCION_ME { get; set; }
       
        public int DPD_ID_ME { get; set; }
        public Guid SOB_CREADO_POR { get; set; }
        public DateTime SOB_FECHA_CREACION { get; set; }
        public Guid SOB_ACTUALIZADO_POR { get; set; }
        public DateTime SOB_FECHA_ACTUALIZA { get; set; }
    }
}
