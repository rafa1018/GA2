using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Enum de un procedimiento almacenado de mombre VerificarAfiliado
    /// </summary>
    /// <author>Cristian Gonzalez</author>
    /// <date>09/08/2021</date>
    public enum EnumVerificarAfiliadoParametros
    {
        [Description("CTA_ID")]
		CTA_ID,
		[Description("CTA_NUMERO")]
		CTA_NUMERO,
		[Description("CLI_ID")]
		CLI_ID,
		[Description("TCT_ID")]
		TCT_ID,
		[Description("ECT_ID")]
		ECT_ID,
		[Description("CCN_ID")]
		CCN_ID,
		[Description("DCT_ID")]
		DCT_ID,
		[Description("CTA_FECHA_CREACION")]
		CTA_FECHA_CREACION,
		[Description("CTA_FECHA_CIERRE")]
		CTA_FECHA_CIERRE,
		[Description("CTA_FECHA_PRIMER_APORTE")]
		CTA_FECHA_PRIMER_APORTE,
		[Description("CTA_SALDO")]
		CTA_SALDO,
		[Description("CTA_SALDO_CANJE")]
		CTA_SALDO_CANJE,
		[Description("CTA_SALDO_DISPONIBLE")]
		CTA_SALDO_DISPONIBLE,
		[Description("CTA_CUOTAS")]
		CTA_CUOTAS,
		[Description("MVT_ID")]
		MVT_ID,
		[Description("CNC_ID")]
		CNC_ID,
		[Description("MVT_VALOR")]
		MVT_VALOR,
		[Description("CAT_TIPO_MOVIMIENTO")]
		CAT_TIPO_MOVIMIENTO,
		[Description("MVT_FECHA_PROCESO")]
		MVT_FECHA_PROCESO,
		[Description("MVT_ANO_PERIODO")]
		MVT_ANO_PERIODO,
		[Description("MVT_FECHA_MOVIMIENTO")]
		MVT_FECHA_MOVIMIENTO


	}
}
