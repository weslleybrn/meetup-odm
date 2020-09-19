using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Meetup.Odm.Infrastructure.Clients
{
    public class HttpClientService<TResult>: IHttpClientService<TResult>
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        
        public HttpClientService(HttpClient httpClient, ILogger<HttpClientService<TResult>> logger) {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IList<TResult>> GetAllAsync(string url)
        {
            _logger.LogInformation($"Executando o método: {nameof(GetAllAsync)}");

             //Prepara a requisição 
            var responseString = await _httpClient.GetAsync(url);
            
            _logger.LogInformation($"Request: {_httpClient.BaseAddress}{url}");

            //Executa a requisição e aguarda o retorno
            var result = await responseString.Content.ReadAsStringAsync();

            _logger.LogInformation($"Result: {result}");

            //Converte o retorno da api em objeto
            return JsonConvert.DeserializeObject<IList<TResult>>(result);
        }

        public async Task<TResult> PostAsync<TData>(TData data, string url)
        {
            _logger.LogInformation($"Executando o método: {nameof(PostAsync)}");

            //Prepara o objeto a ser enviado
            var dataSerialized = JsonConvert.SerializeObject(data);
            
            _logger.LogInformation($"Payload: {dataSerialized}");
            
            //Envia o objeto como json no payload
            var response = await _httpClient.PostAsync(url, new StringContent(dataSerialized, Encoding.UTF8, "application/json"));
            
            _logger.LogInformation($"Request: {_httpClient.BaseAddress}{url}");

            //Recupera o conteudo do payload
            var result = await response.Content.ReadAsStringAsync();
            
            _logger.LogInformation($"Result: {result}");

            //Converte o retorno da api em objeto
            return  JsonConvert.DeserializeObject<TResult>(result);
        }
    }
}