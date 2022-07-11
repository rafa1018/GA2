namespace GA2.Application.Dto
{
    /// <summary>
    /// DTO cliente sin agregar a BUA
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class ClienteSinCrearDTO
    {
        public int DigitoFuerza { get; set; }
        public int TipoIdentificacion { get; set; }
        public int Identificacion { get; set; }
        public int CodigoMilitar { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Grado { get; set; }
        public int UnidadOperativa { get; set; }
    }
}
