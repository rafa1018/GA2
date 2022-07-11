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
    public partial class IntegracionesGA2
    {

        public async Task<Response<ResponseBiometriaDto>> ValidarBiometria<TOutput>(Uri url, int request, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<Response<ResponseBiometriaDto>>(request, url, headers);
        }
    }
}
