using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Transversals.Commons;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{

    public class IntegracionesGA2VigiaBusinessLogic : IIntegracionesGA2VgiaBusinessLogic
    {
        private readonly IIntegracionesGA2Vigia _integraciones;

        /// <summary>
        /// constructor IntegracionesGA2VigiaBusinessLogic
        /// </summary>
        /// <author>Cristian gonzalez</author>
        /// <date>15/07/2021</date>
        /// <param name="integraciones"></param>

        public IntegracionesGA2VigiaBusinessLogic(IIntegracionesGA2Vigia integraciones)
        {
            _integraciones = integraciones;
        }
        /// <summary>
        /// Logica de negocio Carga Producto Tercero
        /// </summary>
        /// <param name="url">Url de peticion</param>
        /// <param name="cargaProductoTerceroRequest">>Objeto Base endpoint</param>
        /// <param name="userId">Id del usuario</param>
        /// 
        public async Task<Response<object>> CargaProductoTercero(Uri url, CargaProductoTerceroRequest cargaProductoTerceroRequest, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.CargaProductoTercero<object>(url, cargaProductoTerceroRequest, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }
        /// <summary>
        /// Logica de negocio carga Tercero Request
        /// </summary>
        /// <param name="url">Url de peticion</param>
        /// <param name="cargaTerceroRequest">>Objeto Base endpoint</param>
        /// <param name="userId">Id del usuario</param>
        /// 
        public async Task<Response<object>> CargaTercero(Uri url, CargaTerceroRequest cargaTerceroRequest, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.CargaTercero<object>(url, cargaTerceroRequest, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }
        /// <summary>
        /// Logica de negocio carga Transaccion Request
        /// </summary>
        /// <param name="url">Url de peticion</param>
        /// <param name="cargaTransaccionRequest">>Objeto Base endpoint</param>
        /// <param name="userId">Id del usuario</param>
        /// 
        public async Task<Response<object>> CargaTransaccion(Uri url, CargaTransaccionRequest cargaTransaccionRequest, Guid userId)
        {
            var response = new Response<object>();
            var result = await _integraciones.CargaTransaccion<object>(url, cargaTransaccionRequest, response.GetCorrelation(), userId);
            response.Data = JsonConvert.SerializeObject(result);
            return response;
        }
        /// <summary>
        /// Logica de negocio verificacion Tercero Request
        /// </summary>
        /// <param name="url">Url de peticion</param>
        /// <param name="verificacionTerceroRequest">>Objeto Base endpoint</param>
        /// <param name="userId">Id del usuario</param>
        /// 
        public async Task<Response<ResultadoVerificacionTercero>> VerificacionTercero(Uri url, VerificacionTerceroRequest verificacionTerceroRequest, Guid userId)
        {
            var response = new Response<ResultadoVerificacionTercero>();
            var result = await _integraciones.VerificacionTercero<ResultadoVerificacionTercero>(url, verificacionTerceroRequest, response.GetCorrelation(), userId);
            response.Data = result.Data;
            response.IsSuccess = result.IsSuccess;
            response.ReturnMessage = result.ReturnMessage;
            return response;
        }


        
    }
}
