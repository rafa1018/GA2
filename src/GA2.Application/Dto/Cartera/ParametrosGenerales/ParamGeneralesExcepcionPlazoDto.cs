using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ParamGeneralesExcepcionPlazoDto
    {
        public int plazoId { get; set; }
        public int plazoMinimoAnio { get; set; }
        public int plazoMinimoMes { get; set; }
        public int plazoMaximoAnio { get; set; }
        public int plazoMaximoMes { get; set; }
        public DateTime plazoFechaModificacion { get; set; }
        public int plazoModificadoPor { get; set; }
        public bool plazoEstado { get; set; }
        public int IdTipoActor { get; set; }
        public Guid idExcepcion { get; set; }
        public int tipoCredito { get; set; }
        public int unidadEjecutoraId { get; set; }
        public int idExcepcionPlazo { get; set; }
        public string DescripcionTipoActor { get; set; }
        public string NombreUnidadEjecutora { get; set; }

    }
}
