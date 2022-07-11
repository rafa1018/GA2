using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tipo de archivo applicacion
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>16/04/2021</date>
    public class TipoArchivo
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
    }
}
