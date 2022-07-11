using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumCreditoFinancieroParams
    {
        [Description("@SOF_ID")]
        IdSolicitudF,

        [Description("@SOC_ID")]
        IdSolicitudCredito,

        [Description("@SOF_CONCEPTO_SALARIO")]
        ConceptoSalario,

        [Description("@SOF_VALOR_CONCEPTO_SALARIO")]
        ValorConceptoSalario,

        [Description("@SOF_CONCEPTO_1")]
        Concepto1,

        [Description("@SOF_VALOR_CONCEPTO_1")]
        ValorConcepto1,

        [Description("@SOF_CONCEPTO_2")]
        Concepto2,

        [Description("@SOF_VALOR_CONCEPTO_2")]
        ValorConcepto2,

        [Description("@SOF_CONCEPTO_3")]
        Concepto3,

        [Description("@SOF_VALOR_CONCEPTO_3")]
        ValorConcepto3,

        [Description("@SOF_CONCEPTO_4")]
        Concepto4,

        [Description("@SOF_VALOR_CONCEPTO_4")]
        ValorConcepto4,

        [Description("@SOF_CONCEPTO_5")]
        Concepto5,

        [Description("@SOF_VALOR_CONCEPTO_5")]
        ValorConcepto5,

        [Description("@SOF_CONCEPTO_6")]
        Concepto6,

        [Description("@SOF_VALOR_CONCEPTO_6")]
        ValorConcepto6,

        [Description("@SOF_VALOR_TOTAL_INGRESOS")]
        ValorTotalIngresos,

        [Description("@SOF_VALOR_TOTAL_EGRESOS")]
        ValorTotalEgresos,

        [Description("@SOF_DIRECCION_VIVIENDA")]
        DireccionVivienda,

        [Description("@SOF_MATRICULA_VIVIENDA")]
        MatriculaVivienda,

        [Description("@SOF_VALOR_COMERCIAL_VIVIENDA")]
        ValorComercialVivienda,

        [Description("@SOF_MARCA_VEHICULO")]
        MarcaVehiculo,

        [Description("@SOF_PLACA_VEHICULO")]
        PlacaVehiculo,

        [Description("@SOF_VALOR_COMERCIAL_VEHICULO")]
        ValorComercialVehiculo,

        [Description("@SOF_CREADO_POR")]
        CreadoPor,

        [Description("@SOF_FECHA_CREACION")]
        FechaCreacion,

        [Description("@SOF_ACTUALIZADO_POR")]
        ActualizadoPor,

        [Description("@SOF_FECHA_ACTUALIZA")]
        FechaActualiza

    }
}
