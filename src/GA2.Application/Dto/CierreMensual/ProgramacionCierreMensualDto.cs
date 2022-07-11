using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{

    public class ProgramacionCierreMensualDto
    {
        public Guid Id { get; set; }
        public DateTime FechaCargue { get; set; }
        public DateTime FechaProcesamiento { get; set; }
        public Guid UsuarioProcesamiento { get; set; }
        public bool GeneraActualizacion { get; set; }
        public int TipoProceso { get; set; }
        public string TipoProcesoDesc { get; set; }
        public int CuentaAbonoAhorro { get; set; }
        public string ConceptosAhorro { get; set; }
        public int CuentaAbonoCesantias { get; set; }
        public string ConceptosCesantias { get; set; }
        public float IPC { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Estado { get; set; }
        public string EstadoDesc { get; set; }

    }

    public class RespuestaCierreMensualDto
    {
        public Guid Id { get; set; }
        public int Estado { get; set; }
    }

    public class ActualizaCierreMensualDto
    {
        public Guid Id { get; set; }
        public int Estado { get; set; }
    }

    public class ReporteCierreMensualDto
    {
        public Guid IdProgramacion { get; set; }
        public int UnidadEjecutora { get; set; }
        public string UnidadEjecutoraDesc { get; set; }
        public string Concepto { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public float SaldoActual { get; set; }
        public float SaldoAnterior { get; set; }
        public float SaldoInicialIntereses { get; set; }
        public float SaldoInicialIngresos { get; set; }
        public float ValorInteres { get; set; }
        public float SaldoInteresCausado { get; set; }
        public float NuevoSaldo{ get; set; }
        public string Periodo { get; set; }
        public float IPC { get; set; }
    }

}
