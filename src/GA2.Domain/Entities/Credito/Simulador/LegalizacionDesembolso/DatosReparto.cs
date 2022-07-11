using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad Prod. ObtenerCausalDesistimiento
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>22/06/2021</date>
    public class DatosReparto
    {
        public Guid SOC_ID { get;set;}
        public DateTime FECHA_REPARTO { get; set; }
        public string COMPANIA { get; set; }
        public string NIT_COMPANIA { get; set; }
        public string NATURALEZA_COMPANIA { get; set; }
        public string NOTARIA { get; set; }
        public string CIUDSD_NOTARIA { get; set; }
        public string ACTO { get; set; }
        public int VALOR_VENTA { get; set; }
        public string DIRECCION_INMUEBLE { get; set; }
        public string MATRICULAS { get; set; }
        public string DOCUMENTO_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string DOCUMENTO_VENDEDOR { get; set; }
        public string NOMBRE_VENDEDOR { get; set; }
    }
}
