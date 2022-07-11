using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumParamGeneralesCreditoYCartera
    {
        [Description("@PRM_SMLV")]
        parametroSalarioMinimo,
        [Description("@PRM_PORC_INFLACION")]
        porcentajeInflacion,
        [Description("@PRM_PORC_FINANCIA_VIS")]
        porcentajeViviendaVis,
        [Description("@PRM_PORC_FINANCIA_NO_VIS")]
        porcentajeViviendaNoVis,
        [Description("@PRM_NO_SALARIO_MIN_VIS")]
        limiteSalariosVis,
        [Description("@PRM_DIAS_VALIDO_PREAPROB")]
        diasPreaprobado,
        [Description("@PRM_SCORE_MINIMO")]
        puntajeMinimoCentrales,
        [Description("@PRM_PORC_CAPACIDAD_ENDEUDA")]
        porcentajeMinimoEndeudamiento,
        [Description("@PRM_VIGENCIA_CONSULTA_BURO")]
        vigenciaDiasConsultaCentrales,
        [Description("@PRM_PORC_CANON_INI_LSG")]
        porcentajeMinimoCanonInicial,
        [Description("@PRM_PORC_CANON_FIN_LSG")]
        porcentajeMaximoCanonInicial,
        [Description("@PRM_PORC_OPC_COMPRA_LSG")]
        porcentajeMaximoOpcionCompra,
        [Description("@PRM_MESES_LEY_FRECH")]
        maximoMesesAlivioTasa,
        [Description("@PRM_MESES_SUBSIDIO_CUOTA")]
        numeroMesesAlivio,
    }
}
