using GA2.Application.Dto;
using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;

namespace GA2.Application.Main
{
    public interface ITokenClaims
    {
        bool EsTokenValido(string token, out IEnumerable<Claim> claims);
        Task<string> GetTokenAsync(ClienteDto cliente);
        Task<string> GetTokenAsync(User user);
        Task<string> GetTokenToProviderAsync();
        HttpResponseData TokenValidation(HttpRequestData request);
    }
}