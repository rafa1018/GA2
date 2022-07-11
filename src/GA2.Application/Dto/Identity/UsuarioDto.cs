using GA2.Application.Dto.GrupoUsuarios;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Modelo DTo para User
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>22/02/2021</date>
    /// </summary>
    public class UsuarioDto : BaseDto
    {
        [Key]
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Identificacion { get; set; }
        public string TipoIdentificationCode { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int TipoIdentificationId { get; set; }

        public string Token { get; set; }

        public bool Directory { get; set; }

        public string NombreCompleto { get; set; }

        public List<GruposUsuariosDto> Roles { get; set; }

    }
}
