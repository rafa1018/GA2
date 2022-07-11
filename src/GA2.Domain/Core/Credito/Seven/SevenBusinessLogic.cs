using GA2.Application.Dto;
using GA2.Application.Dto.Seven;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core.Credito.Seven
{
    public class SevenBusinessLogic:ISevenBusinesslogic
    {
        private readonly IIntegracionesGA2SevenBusinessLogic _integraciones;
        private readonly IOptions<CHKeysOptions> _optionsCH;
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        public async Task<Response<object>> AnularCDP(AnularCDPRequestDto request)
        {
            var url = _optionsCH.Value.UrlCajaHonor + "api/anularcdp";
            var uri = new Uri(url);

            if(request != default)
            {
                return await this._integraciones.AnularCDP(uri, request, Guid.NewGuid());
            }

            throw new ArgumentNullException();
        }

        public async Task<Response<object>> CrearCDP(CrearCDPRequestDto request)
        {
            var url = _optionsCH.Value.UrlCajaHonor + "api/crearcpd";
            var uri = new Uri(url);

            if (request != default)
            {
                return await this._integraciones.CrearCDP(uri, request, Guid.NewGuid());
            }

            throw new ArgumentNullException();
        }

        public async Task<Response<object>> ObtenerCuentaContable(GetCuentaContableRequestDto request)
        {
            var url = _optionsCH.Value.UrlCajaHonor + "api/obtenerCuentaContable";
            var uri = new Uri(url);

            if (request != default)
            {
                return await this._integraciones.ObtenerCuentaContable(uri, request, Guid.NewGuid());
            }

            throw new ArgumentNullException();
        }
    }
}
