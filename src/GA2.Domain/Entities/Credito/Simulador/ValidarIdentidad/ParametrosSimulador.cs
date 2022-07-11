
namespace GA2.Domain.Entities.Credito.Simulador
{
    /// <summary>
    /// Tabla de Parametros Simulador
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>02/06/2021</date>
    public class ParametrosSimulador
    {
        public int PRM_SMLV { get; set; }
        public int PRM_DIAS_VALIDO_PREAPROB { get; set; }
        public decimal PRM_PORC_LEY_LIBRANZA { get; set; }
        public int PRM_SCORE_MINIMO { get; set; }
        public decimal PRM_PORC_CAPACIDAD_ENDEUDA { get; set; }

    }
}
