using GA2.Application.Dto;
using GA2.Application.Dto.Seven;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public interface IIntegracionesGA2Seven
    {
        Task<object> CrearCDP<TOutput>(Uri url, CrearCDPRequestDto crearCDPRequestDto, Guid correlationId, Guid userId);
        Task<object> AnularCDP<TOutput>(Uri url, AnularCDPRequestDto request, Guid guid, Guid newGuid);
        Task<object> ObtenerCuentaContable<TOutput>(Uri url, GetCuentaContableRequestDto request, Guid guid1, Guid guid2);
    }
}
