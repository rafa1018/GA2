using GA2.Application.Dto.GrupoOpciones;
using GA2.Transversals.Commons;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    public class LoginDto : BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    public class RecuperarContrasenaDto : BaseRequest
    {

        public string Url { get; set; }
        public int Tipo { get; set; }
        public string Numero { get; set; }
    }

    public class ResponseLoginDto : BaseRequest
    {

        public string token { get; set; }

        public List<GrupoOpcionesDto> opciones { get; set; }
       

    }


}
