using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Modelo de adjunto para blogStorage
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>16/04/2021</date>
    public class Adjunto
    {
        public Guid AdjuntoId { get; set; }
        public string NombreArchivo { get; set; }
        public TipoArchivo TipoArchivo { get; set; }
        public string Route { get; set; }
        public Guid TareaId { get; set; }
        public Uri DireccionUrl { get; set; }
    }
}
