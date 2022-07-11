using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Work Manager Core Negocio
    /// <author>Nicolas FLorez Sarrazola</author>
    /// <date>24/02/2021</date>
    /// </summary>
    public class VigiaBusinessLogic : IVigiaBusinessLogic
    {
        private readonly IIntegracionesGA2VgiaBusinessLogic _integraciones;
        private readonly ITokenClaims _tokenClaims;
        private readonly ICreditoRepository _creditoRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<CHKeysOptions> _optionsCH;
        private readonly IOptions<AppMainOptions> _options;
        private readonly IGestorTransUnionBusinessLogic _gestorTu;

        public VigiaBusinessLogic(
                                    IIntegracionesGA2VgiaBusinessLogic integraciones,
                                    ITokenClaims tokenClaims,
                                    ICreditoRepository creditoRepository,
                                    IMapper mapper,
                                    IOptions<CHKeysOptions> optionsCH,
                                    IOptions<AppMainOptions> options,
                                    IGestorTransUnionBusinessLogic gestotTu)
        {
            _integraciones = integraciones;
            _tokenClaims = tokenClaims;
            _creditoRepository = creditoRepository;
            _mapper = mapper;
            _optionsCH = optionsCH;
            _options = options;
            _gestorTu = gestotTu;
        }

        public async Task<Response<ResultadoVerificacionTercero>> VertificacionTercero(VerificacionTerceroRequest request)
        {

            var url = _optionsCH.Value.UrlCajaHonor + "api/vigia/vertificacionTercero";
            var uri = new Uri(url);
            request.Pe_Origen = _options.Value.ApplicationId;
            if (request.Pe_Porcentaje == null) request.Pe_Porcentaje = string.Empty;

            var response= await this._integraciones.VerificacionTercero(uri, request, Guid.NewGuid());
            //await _gestorTu.CrearLogTu(new SolicitudCreditoProductoDto()
            //{
            //    VLT_ID = Guid.NewGuid(),
            //    VLI_ID = Guid.NewGuid(),
            //    VLT_SERVICIO = "ReEnvioCodigoOTP",
            //    VLT_PASO_TRANSACCION = "ID_VISION",
            //    VLT_XML_SOLICITUD = JsonConvert.DeserializeXmlNode("{\"request\":" + JsonConvert.SerializeObject(request), "Root").OuterXml,
            //    VLT_XML_RESPUESTA = JsonConvert.DeserializeXmlNode("{\"response\":" + JsonConvert.SerializeObject(response), "Root").OuterXml,
            //    VLT_ID_APICACION = response.Data.Encontrado,
            //    VLT_CODIGO_RESPUESTA = response.Data.Error,
            //    VLT_TIPO_RESPUESTA = response.Data.Metodo,
            //    VLT_DESCRIPCION_RESPUESTA = response.Data.Error
            //});
            return response; 
        }

       
    }
}
