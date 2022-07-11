using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class CrearMatriculaDto
    {
        public string NumeroMatricula { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Departamento { get; set; }
        public int Cuidad { get; set; }
        public string Direccion { get; set; }
        public int TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string RazonSocial { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
    }
}
