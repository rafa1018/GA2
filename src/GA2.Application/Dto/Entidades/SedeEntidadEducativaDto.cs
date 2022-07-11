using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Sede Entidad Educativa Dto
    /// </summary>
    public class SedeEntidadEducativaDto
    {
        public Guid? IdSedeEntidad { get; set; }
        public Guid? IdEntidad { get; set; }
        public string NombreSede { get; set; }
        public int CiudadId { get; set; }
        public bool Estado { get; set; }

    }
}
