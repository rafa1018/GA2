using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class InconsistenciaSolicitudDto
    {
        public Guid InconsistenciaId { get; set; }
        public Guid ListaInconsistenciaId { get; set; }
        public int GrupoInconsistencia { get; set; }
        public Guid HerramientaId { get; set; }
        public Guid PuntoAtencionId { get; set; }
        public Guid SolicitudId { get; set; }
        public Guid TecnicoId { get; set; }
        public string ObjetoEstudio { get; set; }
        public string Analisis { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
