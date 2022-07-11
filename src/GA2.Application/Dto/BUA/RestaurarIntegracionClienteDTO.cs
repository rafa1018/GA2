using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class RestaurarIntegracionClienteDTO
    {
        public int IdCliente { get; set; }
        public int IdInformacionFinanciera { get; set; }
        public int IdDireccion { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
    }
}
