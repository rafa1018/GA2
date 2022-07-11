using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Tabla de Consecutivos
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>24/04/2021</date>
    public class ConsecutivoDto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public long UltNumero { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualizada { get; set; }

    }
}
