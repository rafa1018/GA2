using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla Cliente - Afiliado
    /// <author>Nicolas Florez Sarraola</author>
    /// <date>12/03/2021</date>
    /// </summary>
    public class Cliente
    {
        #region Cliente
        public int CLI_ID { get; set; }
        public int TPA_ID { get; set; }
        public int TID_ID { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public DateTime CLI_FECHA_EXPEDICION { get; set; }
        public int DPP_ID_PAIS_EXPEDICION { get; set; }
        public int DPC_ID_IDENTIFICACION_EXPEDIDA { get; set; }
        public int DPD_ID_IDENTIFICACION_EXPEDIDA { get; set; }
        public string CLI_LUGAR_EXPEDICION { get; set; }
        public string CLI_CODIGO_MILITAR { get; set; }
        public string CLI_PRIMER_NOMBRE { get; set; }
        public string CLI_SEGUNDO_NOMBRE { get; set; }
        public string CLI_PRIMER_APELLIDO { get; set; }
        public string CLI_SEGUNDO_APELLIDO { get; set; }
        public DateTime CLI_FECHA_NACIMIENTO { get; set; }
        public int DPP_ID_PAIS_NACIMIENTO { get; set; }
        public int DPD_ID { get; set; }
        public int DPC_ID { get; set; }
        public string CLI_LUGAR_NACIMIENTO { get; set; }
        public string CAT_SEXO { get; set; }
        public string CAT_ESTADO_CIVIL { get; set; }
        public int CLI_PROFESION { get; set; }
        public string CLI_UNIDAD { get; set; }
        public int CTG_ID { get; set; }
        public int FRZ_ID { get; set; }
        public int GRD_ID { get; set; }
        public int UEJ_ID { get; set; }
        public DateTime CLI_FECHA_INSCRIPCION { get; set; }
        public DateTime CLI_FECHA_ALTA { get; set; }
        public int CLI_REGIMEN { get; set; }
        public DateTime CTS_SLP { get; set; }
        public DateTime CLI_FECHA_REINTEGRO { get; set; }
        public int ECL_ID { get; set; }
        public string CLI_VALIDACION { get; set; }
        public int CLI_ID_PATROCINADOR { get; set; }
        public decimal CLI_PARTICIPACION { get; set; }
        public string CLI_RESOLUCION { get; set; }
        public bool CLI_VALIDACION_BIOMETRICA { get; set; }
        public int ECL_ID_AVAL { get; set; }
        public string CLI_INTEGRACION_GA2_PAYLOAD { get; set; }
        #endregion

        #region Información económica
        public int CIE_ID { get; set; }
        public int ACC_ID { get; set; }
        public DateTime CIE_FECHA_INFO_ECONOMICA { get; set; }
        public decimal CIE_INGRESO_MENSUAL { get; set; }
        public decimal CIE_EGRESO_MENSUAL { get; set; }
        public decimal CIE_TOTAL_ACTIVOS { get; set; }
        public decimal CIE_TOTAL_PASIVOS { get; set; }
        public decimal CIE_TOTAL_PATRIMONIO { get; set; }
        public decimal CIE_INGRESO_ADICIONAL { get; set; }
        public string CIE_CONCEPTO_INGRESO_ADICIONAL { get; set; }
        public bool CIE_TRANS_EXTRANJERO { get; set; }
        public int MND_ID { get; set; }
        public decimal CIE_VALOR_TRANSFERENCIA { get; set; }
        #endregion

        #region Direccion
        public int DRC_ID { get; set; }
        public int DRC_CONSECUTIVO { get; set; }
        public int DPP_ID_RESIDENCIA { get; set; }
        public int DPD_ID_RESIDENCIA { get; set; }
        public int DPC_ID_RESIDENCIA { get; set; }
        public string DRC_CIUDAD_RESIDENCIA_EXTRANJERO { get; set; }
        public int TPC_TIPO_CALLE { get; set; }
        public int DRC_NUMERO_1 { get; set; }
        public int LTR_LETRA_1 { get; set; }
        public int BS_BIS_1 { get; set; }
        public int CRD_CARDINAL_1 { get; set; }
        public int DRC_NUMERO_2 { get; set; }
        public int LTR_LETRA_2 { get; set; }
        public int BS_BIS_2 { get; set; }
        public int CRD_CARDINAL_2 { get; set; }
        public int DRC_NUMERO_3 { get; set; }
        public int LTR_LETRA_3 { get; set; }
        public int CRD_CARDINAL_3 { get; set; }
        public string DRC_COMPLEMENTO_DIRECCION { get; set; }
        public string DRC_DIRECCION { get; set; }
        public string DRC_BARRIO { get; set; }
        public int TPD_ID { get; set; }
        public int ID_SISTEMA_SIS { get; set; }
        #endregion

        #region Correos
        public int DCE_ID { get; set; }
        public string DCE_CORREO { get; set; }
        public int TCE_ID { get; set; }
        public bool DCE_ENVIO_INFORMACION { get; set; }
        public bool DCE_ACTIVO { get; set; }
        #endregion

        #region Telefonos
        public int DTL_ID { get; set; }
        public int DTL_INDICATIVO_PAIS { get; set; }
        public int DTL_INDICATIVO_CIUDAD { get; set; }
        public string DTL_TELEFONO { get; set; }
        public int TPT_ID { get; set; }
        public bool DTL_ENVIO_INFORMACION { get; set; }
        public bool DTL_ACTIVO { get; set; }
        #endregion

        #region Conyuge
        public int CNY_ID { get; set; }
        public int CNY_TID_ID { get; set; }
        public string CNY_IDENTIFICACION { get; set; }
        public string CNY_PRIMER_NOMBRE { get; set; }
        public string CNY_SEGUNDO_NOMBRE { get; set; }
        public string CNY_PRIMER_APELLIDO { get; set; }
        public string CNY_SEGUNDO_APELLIDO { get; set; }
        public bool CNY_ACTIVO { get; set; }
        #endregion
    }


    public class InfoCliente
    {

        public int CLI_ID { get; set; }
        public string CLI_PRIMER_NOMBRE { get; set; }
        public string CLI_SEGUNDO_NOMBRE { get; set; }
        public string CLI_PRIMER_APELLIDO { get; set; }
        public string CLI_SEGUNDO_APELLIDO { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public int TID_ID { get; set; }
        public int CTG_ID { get; set; }
        public int FRZ_ID { get; set; }
        public int GRD_ID { get; set; }
        public int UEJ_ID { get; set; }
        public int TPF_ID { get; set; }
        public DateTime CLI_FECHA_INSCRIPCION { get; set; }
        public DateTime CLI_FECHA_ALTA { get; set; }

    }

    public class InfoDetalleCliente
    {

        public string TIPO_IDENTIFICACION { get; set; }
        public string CATEGORIA { get; set; }
        public string FUERZA { get; set; }
        public string GRADO { get; set; }
        public string UNIDADE_EJECUTORA { get; set; }

        public string TIPO_AFILIACION { get; set; }



    }


}
