using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Entidad Educativa Dto
    /// </summary>
    public class BloqueoEntidadEducativaDto
    {
        public Guid IdBloqueo { get; set; }
        public Guid IdEntidad { get; set; }
        public int IdTipoOperacion { get; set; }
        public int IdCausalBloqueo { get; set; }
        public DateTime FechaBloqueo { get; set; }
        public Guid FuncionarioBloqueo { get; set; }

    }
}
