using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ICuentasClientesBusinessLogic
    {
        Task<Response<InfoClienteDto>> ObtenerInformacionCliente(int tpo_identificacion, string num_identificacion);
    }
}
