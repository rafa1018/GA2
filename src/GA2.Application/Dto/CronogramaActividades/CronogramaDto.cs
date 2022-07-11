using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class CronogramaDto
    {
        public int Id { get; set; }
        public int IdFuerza { get; set; }
        public string FuerzaDescripcion { get; set; }
        public int IdUnidadEjecutora { get; set; }
        public string NombreUnidadEjecutora { get; set; }
        public DateTime FechaReporte { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Periodo { get; set; }
        public int IdFormato { get; set; }
        public string DescripcionFormato { get; set; }
        public int IdMedioEnvio { get; set; }
        public string DescripcionMedioEnvio { get; set; }
    }
}
