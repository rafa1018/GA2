using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudPropietarioDto
    {
        public List<TipoMatricula> Matricula { get; set; }
        public string NumeroIdentificacion { get; set; }
        public TipoIdentificacionMatricula TipoIdentificacion { get; set; }
        public string RazonSocial { get; set; }

    }

    public class TipoIdentificacionMatricula
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class TipoMatricula
    {
        public string Id { get; set; }
        public string NumeroMatricula { get; set; }
        public string Estado { get; set; }
    }
}
