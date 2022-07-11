using System;

namespace GA2.Application.Dto
{

    /// <summary>
    /// Propiedades Dto de Flujo 
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>24/04/2021</date>
    public class FlujoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
