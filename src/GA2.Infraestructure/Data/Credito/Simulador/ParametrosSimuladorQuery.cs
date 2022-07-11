
namespace GA2.Infraestructure.Data.Credito
{
    /// <summary>
    /// Query string Parametros Simulador
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>02/06/2021</date>
    public static class ParametrosSimuladorQuery
    {
        public const string QueryParametros = @"Select  PRM_SMLV*PRM_NO_SALARIO_MIN_VIS as PRM_SMLV,PRM_DIAS_VALIDO_PREAPROB, PRM_PORC_LEY_LIBRANZA, PRM_PORC_LEY_LIBRANZA, PRM_PORC_CAPACIDAD_ENDEUDA From PRM_SIMULADOR; ";

    }
}
