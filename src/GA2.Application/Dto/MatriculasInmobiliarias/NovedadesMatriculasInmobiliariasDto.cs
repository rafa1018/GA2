using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class NovedadesMatriculasInmobiliariasDto
    {
        public Guid Id { get; set; }
        public DateTime FechaNovedad { get; set; }
        public Guid MatriculaId { get; set; }
        public Guid TipoOperacionId { get; set; }
        public int TipoSolicitudId { get; set; }
        public int CausalId { get; set; }
        public string SolicitudId { get; set; }
        public string UserCreadorId { get; set; }
    }

    public class HistotialNovedadesMatriculasInmobiliariasDto
    {

        public Guid IdTipoOperacion  { get; set; }
        public string TipoOperacion { get; set; }
        public string NumeroMatricula { get; set; }
        public DateTime FechaNovedad { get; set; }
        public Guid TipoSolicitudId{ get; set; }
        public string TipoSolicitud { get; set; }
        public int CausalId { get; set; }
        public string Causal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Guid CreatePorId { get; set; }
        public string CreatePor { get; set; }
        public int IdTipoSolicitud { get; set; }
        public string DescripcionTipoSolicitud { get; set; }

    }
}
