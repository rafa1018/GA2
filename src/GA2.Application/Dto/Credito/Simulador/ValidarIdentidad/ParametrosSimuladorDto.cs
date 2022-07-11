
namespace GA2.Application.Dto
{
    /// <summary>
    /// Tabla de Parametros Simulador
    /// </summary>
    /// <author>German Eduardo Guarnizo</author>
    /// <date>02/06/2021</date>
    public class ParametrosSimuladorDto
    {
        public int SalarioMinimoLV { get; set; }
        public int DiasValidoPreaprobado { get; set; }
        public decimal PorcLeyVivienda { get; set; }
        public int ScoreMinimo { get; set; }
        public decimal PorcCapacidadEndeudamiento { get; set; }
    }
}
