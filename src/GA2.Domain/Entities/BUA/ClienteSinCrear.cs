namespace GA2.Domain.Entities
{
    /// <summary>
    /// Cliente sin afiliar a BUA
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    /// </summary>
    public class ClienteSinCrear
    {
        public int DIGITO_FUERZA { get; set; }
        public int TIPO_IDENTIFICACION { get; set; }
        public int IDENTIFICACION { get; set; }
        public int CODIGO_MILITAR { get; set; }
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public int GRADO { get; set; }
        public int UNIDAD_OPERATIVA { get; set; }
    }
}
