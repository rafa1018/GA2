using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad componentes de un archivo de nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class Componentes : BaseEntity
    {
        public Guid TRANSACTION_ID { get; set; }
        public Documento DOCUMENT { get; set; }
        public FileNameReported FILENAME { get; set; }
        public HeaderFileReported HEADER { get; set; }
        public List<BodyFile> BODY { get; set; }
        public EndFileReported END { get; set; }

    }
}
