using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de parametrizacion de seguros
    /// <author>Andres Riaño</author>
    /// <date>15/03/2021</date>
    /// </summary>
    public class ParametrizacionSeguroDto
    {
        public int Id { get; set; }
        public decimal SeguroVida { get; set; }
        public decimal SeguroTodoRiesgo { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
        public bool Estado { get; set; }
    }
}
