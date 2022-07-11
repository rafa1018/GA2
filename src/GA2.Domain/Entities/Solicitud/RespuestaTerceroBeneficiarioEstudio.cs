using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class RespuestaTerceroBeneficiarioEstudio
    {
        public string TID_ID_FK { get; set; }
        public string TER_NUMERO_DOCUMENTO { get; set; }
        public string TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public string TER_PARENTESCO { get; set; }
        public string TID_DESCRIPCION { get; set; }
        public string CVL_DESCRIPCION { get; set; }
    }
}
