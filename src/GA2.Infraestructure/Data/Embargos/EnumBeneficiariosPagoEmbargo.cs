using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumBeneficiariosPagoEmbargo
    {
        [Description("@BPE_ID")]
		BPE_ID,

		[Description("@EBA_ID")]
		EBA_ID,

		[Description("@TID_ID")]
		TID_ID,

		[Description("@BPE_NUMERO_IDENTIFICACION")]
		BPE_NUMERO_IDENTIFICACION,

		[Description("@BPE_PRIMER_NOMBRE")]
		BPE_PRIMER_NOMBRE,

		[Description("@BPE_SEGUNDO_NOMBRE")]
		BPE_SEGUNDO_NOMBRE,

		[Description("@BPE_PRIMER_APELLIDO")]
		BPE_PRIMER_APELLIDO,

		[Description("@BPE_SEGUNGO_APELLIDO")]
		BPE_SEGUNGO_APELLIDO,

		[Description("@BPE_FECHA_REGISTRO")]
		BPE_FECHA_REGISTRO,

		[Description("@BPE_FECHA_ACTUALIZACION")]
		BPE_FECHA_ACTUALIZACION,

		[Description("@BPE_CREADOPOR")]
		BPE_CREADOPOR,

		[Description("@BPE_ACTUALIZADOPOR")]
		BPE_ACTUALIZADOPOR,

		[Description("@BPE_ESTADO")]
		BPE_ESTADO,

	}
}
