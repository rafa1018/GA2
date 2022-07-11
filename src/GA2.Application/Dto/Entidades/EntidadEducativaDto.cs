using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Entidad Educativa Dto
    /// </summary>
    public class EntidadEducativaDto
    {
        public Guid? IdEntidad { get; set; }
        public int TipoIdentificacion{ get; set;}
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string CorreoElectronico { get; set; }
        public int Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public bool Estado { get; set; }

    }
}
