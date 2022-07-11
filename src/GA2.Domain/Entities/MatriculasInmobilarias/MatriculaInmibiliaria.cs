using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class MatriculaInmibiliaria
    {
        public Guid MAI_ID { get; set; }
        public string MAI_NUMERO_MATRICULA { get; set; }
        public DateTime MAI_FECHA_REGISTRO { get; set; }
        public string MAI_DIRECCION { get; set; }
        public string DPD_ID_FK { get; set; }
        public string DPC_ID_FK { get; set; }
        public string PRP_TIPO_IDENTIFICACION { get; set; }
        public string PRP_NUMERO_IDENTIFICACION { get; set; }
        public string PRP_NOMBRE_RAZON_SOCIAL { get; set; }
    }

    public class PropietariosMatriculasInmobiliarias {

        public Guid MAI_ID { get; set; }
        public Guid PRP_ID { get; set; }
        public string PRP_NUMERO_IDENTIFICACION { get; set; }
        public string PRP_NOMBRE_RAZON_SOCIAL { get; set; }
        public string PRP_TIPO_IDENTIFICACION { get; set; }
        public int TID_ID { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }

    }

    public class NovedadesMatriculasInmobiliarias
    {

        public Guid NVM_ID { get; set; }
        public DateTime NVM_FECHA_NOVEDAD { get; set; }
        public Guid MAI_ID { get; set; }
        public Guid TOP_ID { get; set; }
        public int TSN_ID { get; set; }
        public int CAN_ID { get; set; }
        public string SOL_ID { get; set; }
        public string NVM_CREATEDOPOR { get; set; }



    }

    public class HistotialNovedadesMatriculasInmobiliarias
    {

        public Guid ID_TIPO_OPERACION { get; set; }
        public string TIPO_OPERACION { get; set; }
        public string NUMERO_MATRICULA { get; set; }
        public DateTime FECHA_NOVEDAD { get; set; }
        public Guid TIPO_SOLICITUD_ID { get; set; }
        public string TIPO_SOLICITUD { get; set; }
        public int CAUSAL_ID { get; set; }
        public string CAUSAL { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public Guid CREATEDOPOR_ID { get; set; }
        public string CREATEDOPOR { get; set; }
        public int TSN_ID { get; set; }
        public string TSN_DESCRIPCION { get; set; }


    }

    public class OperacionesMatriculas {

        public Guid TOP_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public bool ESTADO { get; set; }

    }

    public class CausalNovedamatricula {

        public Guid CAN_ID { get; set; }
        public Guid TOP_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public bool ESTADO { get; set; }

    }

    public class CrearMatricula
    {
        public string MAI_NUMERO_MATRICULA { get; set; }
        public DateTime MAI_FECHA_REGISTRO { get; set; }
        public string MAI_DIRECCION { get; set; }
        public int DPD_DEPARTAMENTO { get; set; }
        public int DPC_NOMBRE_CIUDAD { get; set; }
        public int PRP_TIPO_IDENTIFICACION { get; set; }
        public string PRP_NUMERO_IDENTIFICACION { get; set; }
        public string PRP_NOMBRE_RAZON_SOCIAL { get; set; }
        public string CORREO { get; set; }
        public string TELEFONO { get; set; }
    }
}
