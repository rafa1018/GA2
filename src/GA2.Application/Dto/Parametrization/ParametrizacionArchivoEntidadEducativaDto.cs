using System;

namespace GA2.Application.Dto
{
    public class ParametrizacionArchivoEntidadEducativaDto
    {
        public Guid IdParametrizacion { get; set; }
        public Guid IdEntidad { get; set; }
        public string NombreArchivo { get; set; }
        public string DescripcionArchivo { get; set; }
        public bool EstadoRequerido { get; set; }
        public bool EstadoActivo { get; set; }
        public int Ordenamiento { get; set; }
    }
}
