using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class IntegracionesGA2FenixBusinessLogic : IIntegracionesGA2FenixBusinessLogic
    {
        private readonly IIntegracionesGA2Fenix _integraciones;

        public IntegracionesGA2FenixBusinessLogic(IIntegracionesGA2Fenix integraciones)
        {
            _integraciones = integraciones;
        }

        public async Task<Response<ResponseBiometriaDto>> ValidarBiometria(Uri url, int request, Guid userId)
        {
            var response = new Response<ResponseBiometriaDto>();
            var result = await _integraciones.ValidarBiometria<Response<ResponseBiometriaDto>>(url, request, response.GetCorrelation(), userId);
            response.Data = result.Data;
            response.ReturnMessage = result.ReturnMessage;
            response.IsSuccess = result.IsSuccess;
            return response;
        }
    }
}
