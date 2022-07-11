using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entity EstadoCivil
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>25/03/2021</date>
    public class EstadoCivil
    {
        [Key]
        public int STD_ID { get; set; }
        public string STD_DESCRIPCION { get; set; }
    }
}
