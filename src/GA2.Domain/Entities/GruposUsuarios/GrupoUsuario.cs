using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities.GruposUsuarios
{
    public class GrupoUsuario
    {

        public int ID { get; set; }
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO { get; set; }


    }

    public class UsuariosPorGrupos
    {

        public int GRP_ID { get; set; }
        public string USR_ID { get; set; }

    }


    public class GruposPorOpciones
    {

        public int GRP_ID { get; set; }
        public int OPC_ID { get; set; }

    }
}
