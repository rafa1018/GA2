using GA2.Application.Dto;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public partial class IntegracionesGA2 : ProviderRequestFactory, IIntegracionesGA2Bua, IIntegracionesGA2Vigia, IIntegracionesGA2WorkManager, IIntegracionesGA2Fenix, IIntegracionesGA2Haberes, IIntegracionesGA2Seven
    {
        private readonly IOptions<AppMainOptions> _options;
        private readonly IOptions<CHKeysOptions> _choptions;

        public IntegracionesGA2(
            IOptions<AppMainOptions> options,
            ITokenClaims tokenClaims,
            IOptions<CHKeysOptions> choptions) : base(tokenClaims)
        {
            _options = options;
            _choptions = choptions;
        }

        private async Task<Response<TokenDto>> ObtenerToken(Guid correlation, Guid userId)
        {
            var payloadLogin = this.PayloadObtenerToken(correlation, userId);
            var urlLogin = new Uri($"{_choptions.Value.UrlCajaHonor}{_choptions.Value.LoginCajaHonor}");
            return await PostExternalAsync<Response<TokenDto>>(payloadLogin, urlLogin);
        }

        private LoginIntegracionesDto PayloadObtenerToken(Guid correlation, Guid userId)
        {
            return new LoginIntegracionesDto
            {
                AplicacionId = _options.Value.ApplicationId,
                Contrasena = _options.Value.Password,
                NombreAplicacion = _options.Value.ApplicationName,
                Id = correlation,
                UserId = userId
            };
        }
    }
}

