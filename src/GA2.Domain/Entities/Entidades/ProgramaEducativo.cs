using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Programa educativo
    /// </summary>
    public class ProgramaEducativo
    {
        public Guid PGE_ID { get; set; }
        public string PGE_DESCRIPCION { get; set; }
        public bool PGE_ESTADO { get; set; }
        public Guid PGE_CREATEDOPOR { get; set; }
        public DateTime PGE_FECHACREACION { get; set; }
        public Guid PGE_MODIFICADOPOR { get; set; }
        public DateTime PGE_FECHAMODIFICACION { get; set; }
    }
}