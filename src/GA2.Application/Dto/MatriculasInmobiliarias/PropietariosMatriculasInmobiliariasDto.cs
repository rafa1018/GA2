using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class PropietariosMatriculasInmobiliariasDto
    {

        public Guid MaiId { get; set; }
        public Guid PrpId { get; set; }
        public string PrpNumeroIdentificacion { get; set; }
        public string PrpNombreRazonSocial { get; set; }
        public int PrpIdTipoIdentificacion { get; set; }
        public string PrpTipoIdentificacion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }


    }
}
