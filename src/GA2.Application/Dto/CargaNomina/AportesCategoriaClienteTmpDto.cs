using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Modelo Dto temporal de cargue nomina
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>27/04/2021</date>
    public class AportesCategoriaClienteTmpDto
    {
        public int IdRegistro { get; set; }
        public int Categoria { get; set; }
        public int CuotasAcumuladas { get; set; }
        public DateTime FechaUltimaCuota { get; set; }
        public DateTime FechaPrimeraCuota { get; set; }
    }
}
