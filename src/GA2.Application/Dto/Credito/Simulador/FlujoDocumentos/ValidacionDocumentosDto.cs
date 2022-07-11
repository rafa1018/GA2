using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ValidacionDocumentosDto
    {
        public Guid IdSolicitud { get; set; }
        public int IdTipoCredito { get; set; }
        public int Orden { get; set; }
        public string Principal { get; set; }
        public int DocSeguroVida { get; set; }
        public int DocSeguroHogar { get; set; }
        public string IdFlujo { get; set; }
        public string IdAfl { get; set; }
        public string IdDca { get; set; }
        public string IdTdc { get; set; }
        public string TdcDescripcion { get; set; }
        public string DcaObligatorio { get; set; }
        public string DcaOrden { get; set; }
    }
}
