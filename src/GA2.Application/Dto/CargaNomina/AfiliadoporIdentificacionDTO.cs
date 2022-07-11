using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    /// <summary>
    /// DTO de un procedimiento almacenado de mombre ObtenerIdafiliadoporIdentificacion
    /// </summary>
    /// <author>Cristian Gonzalez </author>
    /// <date>19/08/2021</date>
    public class AfiliadoporIdentificacionDTO
    {
        public string NumeroIidentificacion { get; set; }
        public int IdCliente { get; set; }
    }
}
