using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Application.Main
{
    /// <summary>
    /// Proveedor de peticiones
    /// <author>Oscar Julian Rojas</author>
    /// <date>25/03/2021</date>
    /// </summary>
    public abstract class ProviderRequestFactory
    {
        /// <summary>
        /// Dependencia de tokens
        /// </summary>
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Settings jsons newton
        /// </summary>
        private readonly JsonSerializerSettings _serializerSettings;

        /// <summary>
        /// Constructor Inyecta Tokens
        /// </summary>
        /// <param name="tokenClaims"></param>
        protected ProviderRequestFactory(ITokenClaims tokenClaims)
        {
            _tokenClaims = tokenClaims;
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
            };
        }

        /// <summary>
        /// Request metodo Get
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns>TOutput</returns>
        public async Task<TOutput> GetAsync<TOutput>(Uri uri, Dictionary<string, string> headers = null) where TOutput : new()
        {
            var token = await this._tokenClaims.GetTokenToProviderAsync();
            HttpClient httpClient = CreateHttpCliente(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            var response = await httpClient.GetAsync(uri);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings);

        }

        /// <summary>
        /// Request metodo Get Externos
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns>TOutput</returns>
        public async Task<T> GetExternalAsync<T>(Uri uri, Dictionary<string, string> headers = null, string token = null)
        {
            HttpClient httpClient = CreateHttpClienteExternal(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            var response = await httpClient.GetAsync(uri);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return GetJsonGenericType<T>(serialized, _serializerSettings);

        }

        /// <summary>
        /// Request metodo Post
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="obj">Objecto enviado como body</param>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns>TOutput</returns>
        public async Task<TOutput> PostAsync<TOutput>(TOutput obj, Uri uri, Dictionary<string, string> headers = null) where TOutput : new()
        {
            var token = await this._tokenClaims.GetTokenToProviderAsync();
            HttpClient httpClient = CreateHttpCliente(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            // Linea provisional
            // var content = new StringContent(JsonConvert.SerializeObject(obj));
            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");


            HttpResponseMessage response = await httpClient.PostAsync(uri, content);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings);
        }

        /// <summary>
        /// Request metodo Post
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="obj">Objecto enviado como body</param>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns>TOutput</returns>
        public async Task<TOutput> PostAsyncV2<TOutput>(dynamic obj, Uri uri, Dictionary<string, string> headers = null) where TOutput : new()
        {
            var token = await this._tokenClaims.GetTokenToProviderAsync();
            HttpClient httpClient = CreateHttpCliente(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            // Linea provisional
            // var content = new StringContent(JsonConvert.SerializeObject(obj));
            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");


            HttpResponseMessage response = await httpClient.PostAsync(uri, content);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings);
        }

        /// <summary>
        /// Request metodo Post
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="obj">Objecto enviado como body</param>
        /// <param name="token">Token de peticion</param>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns>TOutput</returns>
        public async Task<TOutput> PostExternalAsync<TOutput>(object obj,
                                                              Uri uri,
                                                              Dictionary<string, string> headers = null,
                                                              string token = null) where TOutput : new()
        {
            HttpClient httpClient = CreateHttpClienteExternal(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings);
        }

        /// <summary>
        /// Request metodo Post con carga de archivos
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="obj">Objecto a crear</param>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns>TOutput</returns>
        public async Task<TOutput> PostAsyncFile<TOutput>(object obj, Uri uri, Dictionary<string, string> headers = null) where TOutput : new()
        {
            var token = await this._tokenClaims.GetTokenToProviderAsync();
            HttpClient httpClient = CreateHttpCliente(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            var content = new StringContent(JsonConvert.SerializeObject(obj));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings);
        }

        /// <summary>
        /// Request metodo Put
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="obj">Objecto a actualizar</param>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns>TOutput</returns>
        public async Task<TOutput> PutAsync<TOutput>(TOutput obj, Uri uri, Dictionary<string, string> headers = null) where TOutput : new()
        {
            var token = await this._tokenClaims.GetTokenToProviderAsync();
            HttpClient httpClient = CreateHttpCliente(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            var content = new StringContent(JsonConvert.SerializeObject(obj));

            HttpResponseMessage response = await httpClient.PutAsync(uri, content);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings);
        }

        /// <summary>
        /// Request metodo Path 
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="obj">Objecto a actualizar</param>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns></returns>
        public async Task<TOutput> PatchAsync<TOutput>(TOutput obj, Uri uri, Dictionary<string, string> headers = null) where TOutput : new()
        {
            var token = await this._tokenClaims.GetTokenToProviderAsync();
            HttpClient httpClient = CreateHttpCliente(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            var content = new StringContent(JsonConvert.SerializeObject(obj));

            HttpResponseMessage response = await httpClient.PatchAsync(uri, content);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings);
        }

        /// <summary>
        /// Request Method delete
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="obj">Objecto a actualizar</param>
        /// <param name="uri">Direccion http de metodo</param>
        /// <param name="headers">headers opcionales</param>
        /// <returns></returns>
        public async Task<TOutput> DeleteAsync<TOutput>(TOutput obj, Uri uri, Dictionary<string, string> headers = null) where TOutput : new()
        {
            var token = await this._tokenClaims.GetTokenToProviderAsync();
            HttpClient httpClient = CreateHttpCliente(token);

            if (headers != null)
                AddHeaderParameter(httpClient, headers);

            HttpResponseMessage response = await httpClient.DeleteAsync(uri);
            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TOutput>(serialized, _serializerSettings);
        }


        /// <summary>
        /// Create cliente
        /// </summary>
        /// <param name="token">token Inyectado de TokemClaims</param>
        /// <returns>string jwt</returns>
        private HttpClient CreateHttpCliente(string token = null)
        {
            HttpClient client = null;
            if (!string.IsNullOrEmpty(token))
            {
                HttpClientHandler clientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };

                client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }

        /// <summary>
        /// Create cliente peticiones externas
        /// </summary>
        /// <param name="token">token Inyectado de TokemClaims</param>
        /// <returns>string jwt</returns>
        private HttpClient CreateHttpClienteExternal(string token = null)
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient client = null;
            if (!string.IsNullOrEmpty(token))
            {
                client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            else client = new HttpClient(clientHandler);

            return client;
        }


        /// <summary>
        /// Añadir Headers adicionales
        /// </summary>
        /// <param name="httpClient">Instacia de httpclient</param>
        /// <param name="parameters">Parametros opcionales de headers</param>
        private void AddHeaderParameter(HttpClient httpClient, Dictionary<string, string> parameters)
        {
            if (httpClient == null)
                return;

            if (parameters == null)
                return;

            foreach (var i in parameters)
                httpClient.DefaultRequestHeaders.Add(i.Key, i.Value);
        }

        /// <summary>
        /// Manejo del Response data
        /// </summary>
        /// <param name="response">Resultado obtenido</param>
        /// <returns>Datos de consulta o peticion</returns>
        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(content);
                }

                throw new HttpRequestException(content);
            }
        }

        /// <summary>
        /// Obtiene el tipo y define la serializacion apartir del tipo envido
        /// Solo para peticiones externas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJSON"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        private static T GetJsonGenericType<T>(string strJSON, JsonSerializerSettings settings)
        {
            var generatedType = JsonConvert.DeserializeObject<T>(strJSON, settings);
            return (T)Convert.ChangeType(generatedType, typeof(T));
        }
    }
}
