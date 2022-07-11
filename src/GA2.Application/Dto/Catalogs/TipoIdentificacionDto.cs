namespace GA2.Application.Dto
{
    public class TipoIdentificacionDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool EsEmpresarial { get; set; }
        public bool EsActivo { get; set; }
        public int ERP { get; set; }
        public int Vigia { get; set; }
        public int Embargo { get; set; }
    }
}
