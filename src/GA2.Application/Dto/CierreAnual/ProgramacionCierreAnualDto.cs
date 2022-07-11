using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{

    public class ProgramacionCierreAnualDto
    {
        public Guid Id { get; set; }
        public DateTime FechaCargue { get; set; }
        public DateTime FechaProcesamiento { get; set; }
        public Guid UsuarioProcesamiento { get; set; }
        public bool GeneraActualizacion { get; set; }
        public int TipoProceso { get; set; }
        public int CuentaAbonoAhorro { get; set; }
        public string ConceptosAhorro { get; set; }
        public int CuentaAbonoCesantias { get; set; }
        public string ConceptosCesantias { get; set; }
        public float IPC { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Estado { get; set; }

    }

    public class RespuestaCierreAnualDto
    {
        public Guid Id { get; set; }
        public int Estado { get; set; }
    }

    public class ActualizaCierreAnualDto 
    {       
        public Guid Id { get; set; }
        public int Estado { get; set; }
        
    }


}
