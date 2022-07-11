using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TipoActorDto
    {
        public int IdTipoActor { get; set; }
        public string DescripcionTipoActor { get; set; }
        public bool ActivoTipoActor { get; set; }
        public bool AplicaCuentaTipoActor { get; set; }
        public bool AplicaClienteTipoActor { get; set; }
        public bool AplicaBloqueoTipoActor { get; set; }
        public bool AplicaUsuarioTipoActor { get; set; }
        public bool OrdenPagoTipoActor { get; set; }
       
  
    }
}
