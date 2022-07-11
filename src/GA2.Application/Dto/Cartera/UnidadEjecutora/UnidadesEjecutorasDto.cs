using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class UnidadesEjecutorasDto
    {
        public int idParametro { get; set; }
        public int idSimulacion { get; set; }
        public int idUnidadEjecutora { get; set; }
        public decimal tasaEa { get; set; }
        public int estado { get; set; }
        public string nombreUnidadEjecutora { get; set; }
        public  Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public string NitUnidadEjecutora { get; set; }
        public string SiglaUnidadEjecutora  { get; set; }
    }
}
