using GA2.Application.Dto;
using GA2.Application.Dto.Seven;
using GA2.Application.Main;
using GA2.Transversals.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class IntegracionesGA2SevenBusinessLogic : IIntegracionesGA2SevenBusinessLogic
    {
        private readonly IIntegracionesGA2Seven _integraciones;

        public IntegracionesGA2SevenBusinessLogic(IIntegracionesGA2Seven integraciones)
        {
            _integraciones = integraciones;
        }

        public async Task<Response<object>> AnularCDP(Uri url, AnularCDPRequestDto request, Guid newGuid)
        {
            var response = new Response<object>();
            var result = await _integraciones.AnularCDP<object>(url, request, response.GetCorrelation(), newGuid);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }

        public async Task<Response<object>> CrearCDP(Uri url, CrearCDPRequestDto crearCDPRequestDto, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.CrearCDP<object>(url, crearCDPRequestDto, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }

        public async Task<Response<object>> ObtenerCuentaContable(Uri url, GetCuentaContableRequestDto request, Guid guid)
        {
            var response = new Response<object>();
            var result = await _integraciones.ObtenerCuentaContable<object>(url, request, response.GetCorrelation(), guid);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }
    }
}
