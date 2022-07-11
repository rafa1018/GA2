using GA2.Application.Dto;
using GA2.Application.Dto.Seven;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public interface ISevenBusinesslogic
    {
        Task<Response<object>> CrearCDP(CrearCDPRequestDto crearCDPRequestDto);
        Task<Response<object>> AnularCDP(AnularCDPRequestDto request);
        Task<Response<object>> ObtenerCuentaContable(GetCuentaContableRequestDto request);
    }
}
