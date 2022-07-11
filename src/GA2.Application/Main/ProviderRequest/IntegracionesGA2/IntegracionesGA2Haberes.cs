using GA2.Application.Dto.Haberes;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    public partial class IntegracionesGA2
    {
        public async Task<Response<String>> GenerarReporteHaberes<TOutput>(Uri url, HaberesRequestDto request, Guid correlationId, Guid userId)
        {
            var token = await this.ObtenerToken(correlationId, userId);
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer { token.Data.Token }" }
            };

            return await PostExternalAsync<Response<String>>(request, url, headers);
        }
    }
}
