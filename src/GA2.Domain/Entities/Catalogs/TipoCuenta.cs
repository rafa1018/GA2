
namespace GA2.Domain.Entities
{
    public class TipoCuenta
    {
        public int TCT_ID { get; set; }
        public string TCT_DESCRIPCION { get; set; }
        public string TCT_PREFIJO { get; set; }
        public string CAT_TIPO_GENERAL_CUENTA { get; set; }
        public bool TCT_APLICAN_INTERESES { get; set; }
        public bool TCT_APLICAN_RENDIMIENTOS { get; set; }
        public bool TCT_APLICAN_CUOTAS { get; set; }
        public bool TCT_ACTIVA { get; set; }
        public string TCT_CENTRO_COSTO { get; set; }
    }
}
