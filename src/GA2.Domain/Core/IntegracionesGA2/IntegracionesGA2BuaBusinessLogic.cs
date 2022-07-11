using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Transversals.Commons;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class IntegracionesGA2BuaBusinessLogic : IIntegracionesGa2BuaBusinessLogic
    {
        //instancia obligatoria para IProvider
        // Instancia obligatoria
        private readonly IIntegracionesGA2Bua _integraciones;

        public IntegracionesGA2BuaBusinessLogic(IIntegracionesGA2Bua integracionesGA2)
        {
            _integraciones = integracionesGA2;
        }

        public async Task<Response<string>> ObtenerBua(Uri url, ObtenerBuaRequest bua, Guid userId)
        {
            var response = new Response<string>();
            var buaResult = await _integraciones.ObtenerBua<object>(url, bua, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(buaResult);
            return response;
        }
    }
}
