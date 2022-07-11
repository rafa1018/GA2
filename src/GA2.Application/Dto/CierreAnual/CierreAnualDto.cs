using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class CierreAnualDto
    {
        public List<int> ListConceptosAhorros { get; set; }
        public int CuentaAbonoAhorros { get; set; }
        public float IPC { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public List<int> ListConceptosCesantias { get; set; }
        public int CuentaAbonoCesantias { get; set; }
        public bool GeneraActualizacion { get; set; }
        public int TipoProceso { get; set; }
    }

    public class ParametrosCierreAnualDto
    {
        public Guid Usuario { get; set; }  
        public bool GeneraActualizacion { get; set; }
        public int TipoProceso { get; set; }
    }

}
