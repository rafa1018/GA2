using GA2.Transversals.Commons;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad fin de archivo nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class EndFileReported : BaseEntity
    {
        public long CONSECUTIVE { get; set; }
        public long FILE_CONTROL_INDICATOR { get; set; }
        public decimal SUM_CONTRIBUTIONS { get; set; }
        public int END_FILE_CODE { get; set; }
    }
}
