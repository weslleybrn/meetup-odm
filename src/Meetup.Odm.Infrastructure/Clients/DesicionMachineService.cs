using System;
using System.Net.Http;
using Meetup.Odm.Infrastructure.Clients.Regras;
using Microsoft.Extensions.Logging;

namespace Meetup.Odm.Infrastructure.Clients
{
    public class DesicionMachineService :  HttpClientService<PodeCadastrarRegra>, IHttpClientService<PodeCadastrarRegra>, IDesicionMachineService
    {
        public DesicionMachineService(HttpClient httpClient, ILogger<DesicionMachineService> logger) 
            : base(httpClient, logger)
        {
        }
    }
}
