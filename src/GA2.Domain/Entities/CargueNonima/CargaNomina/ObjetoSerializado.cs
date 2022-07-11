using GA2.Transversals.Commons;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad JSON enviao a la BD
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class ObjetoSerializado : BaseEntity
    {
        public string Json { get; set; }
    }
}
