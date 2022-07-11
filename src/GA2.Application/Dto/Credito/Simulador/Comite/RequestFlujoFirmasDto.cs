using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class RequestFlujoFirmasDto
    {
        public int IdComite { get; set; }
        public string FechaComite { get; set; }
        public int ComiteNumero { get; set; }
        public string EstadoComite { get; set; }
        public string AttachedFile { get; set; }
        public bool RequiereFirmaGerencia { get; set; }
    }
}
