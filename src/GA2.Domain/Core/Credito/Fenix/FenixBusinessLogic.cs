using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GA2.Domain.Core
{
    public class FenixBusinessLogic : IFenixBusinessLogic
    {
        private readonly IIntegracionesGA2FenixBusinessLogic _integraciones;
        private readonly ITokenClaims _tokenClaims;
        private readonly IMapper _mapper;
        private readonly IOptions<CHKeysOptions> _optionsCH;
        private readonly IOptions<AppMainOptions> _options;

        public FenixBusinessLogic(IIntegracionesGA2FenixBusinessLogic integraciones, ITokenClaims tokenClaims, IMapper mapper, IOptions<CHKeysOptions> optionsCH, IOptions<AppMainOptions> options)
        {
            _integraciones = integraciones;
            _tokenClaims = tokenClaims;
            _mapper = mapper;
            _optionsCH = optionsCH;
            _options = options;
        }

        public async Task<Response<diffgram>> ValidarBiometria(string request)
        {
            var url = _optionsCH.Value.UrlCajaHonor + $"api/validacionbiometria?request={request}";
            var uri = new Uri(url);

            Response<ResponseBiometriaDto> responseBiometria = await this._integraciones.ValidarBiometria(uri, int.Parse(request), Guid.NewGuid());
            var s = new XMLHandler();
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(diffgram));
                var prueba = string.Empty;
                using (StringReader sr = new StringReader(responseBiometria.Data.Nodes[1].ToString()))
                {
                    prueba = sr.ReadToEnd();
                }
                //var algo = ser.Deserialize
                var response = s.Deserialize<diffgram>(prueba);
                return new Response<diffgram>() { Data = response, IsSuccess = responseBiometria.IsSuccess, ReturnMessage = responseBiometria.ReturnMessage };
            }
            catch (Exception ex)
            {
                return new Response<diffgram>() { IsSuccess = responseBiometria.IsSuccess, ReturnMessage = "Usuario sin datos en Fenix" };
            }
        }
    }
}
