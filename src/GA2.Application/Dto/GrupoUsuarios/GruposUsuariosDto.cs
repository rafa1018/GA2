using GA2.Application.Dto.GrupoOpciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto.GrupoUsuarios
{
    public class GruposUsuariosDto
    {
     
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public List<GrupoOpcionesDto> opciones { get; set; }

    }


    public class GruposOpciones
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }

    }
}
