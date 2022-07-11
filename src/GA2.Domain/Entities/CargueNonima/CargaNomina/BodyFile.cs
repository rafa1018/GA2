using GA2.Transversals.Commons;
using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad cuerpo de archivo nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class BodyFile : BaseEntity
    {
        public int CONSECUTIVE { get; set; }
        public int DIGITO_FUERZA { get; set; }
        public int UNIDAD_EJECUTORA { get; set; }
        public int TIPO_IDENTIFICACION { get; set; }
        public string IDENTIFICACION { get; set; }
        public int CODIGO_MILITAR { get; set; }
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public int EMBARGO { get; set; }
        public decimal INGRESO_BASE_CALCULO { get; set; }
        public decimal VALOR { get; set; }
        public DateTime PERIODO { get; set; }
        public int GRADO { get; set; }
        public int UNIDAD_OPERATIVA { get; set; }

    }
}
