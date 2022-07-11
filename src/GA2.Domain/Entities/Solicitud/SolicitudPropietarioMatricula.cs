using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudPropietarioMatricula
    {
        public Guid PRP_ID { get; set; }
        public Guid MAI_ID { get; set; }
        public Guid PMA_CREATEDOPOR { get; set; }

    }
}
