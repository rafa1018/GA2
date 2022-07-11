using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Propiedades Dto de Color Grilla
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>10/05/2021</date>
    public class ColorGrillaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string EstiloColor { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}
