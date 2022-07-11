using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class AfiliacionDto
    {
        public int idAfiliacion { get; set; }
        public int numeroRadicado { get; set; }
        public DateTime fechaRadicado { get; set; }
        public string nombresApellidos { get; set; }
        public string cedula { get; set; }
        public int estado { get; set; }
        public int campoCalidad { get; set; }
        public int tipoAfiliacion { get; set; }
        public bool tramiteAfiliacion { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaPrimerAporte { get; set; }
        public DateTime fechaUltimoAporte { get; set; }
        public int numeroCuotas { get; set; }
        public bool conservaAntiguedad { get; set; }
        public int ratificacionCuotas { get; set; }
        public string campoObservaciones { get; set; }
        public int numeroActoAdministrativo { get; set; }
        public DateTime fechaNotificación { get; set; }
        public bool campoCesantias { get; set; }
        public bool activacionDescuento { get; set; }
        public bool liquidacionCuotaFondoSolidaridad { get; set; }
        public bool reintegroAportes { get; set; }
        public DateTime periodoAportesDesde { get; set; }
        public DateTime periodoAportesHasta { get; set; }
        public decimal asignacionBasicaMensual { get; set; }
        public bool derechoLiquidacionCuotas { get; set; }
        public int documentacionAsociadaTramite { get; set; }
        public string campoObservacionesConceptualizacion { get; set; }
        public int idFuerza { get; set; }
        public int idCategoria { get; set; }
        public int idUnidadEjecutora { get; set; }
        public int idTipofiliacionExtraordinaria { get; set; }
        public int idPorcentajeDescuento { get; set; }

    }
}
