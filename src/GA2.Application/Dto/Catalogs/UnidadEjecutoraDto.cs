using System;

namespace GA2.Application.Dto
{
    public class UnidadEjecutoraDto
    {
        public int Id { get; set; }
        public int TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public DateTime Fecha { get; set; }
        public int Fuerza { get; set; }
        public int Codigo { get; set; }
        public decimal TasaAporte { get; set; }
        public int AreaNegocio { get; set; }
        //public int FRM_ID { get; set; }
        public bool EsAval { get; set; }
    }
}
