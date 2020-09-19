using System;
using System.Net.Http;
using Meetup.Odm.Infrastructure.Clients.Regras;
using Microsoft.Extensions.Logging;

namespace Meetup.Odm.Infrastructure.Clients
{
    public class DesicionMachineService :  HttpClientService<PodeCadastrarRegra>, IHttpClientService<PodeCadastrarRegra>, IDesicionMachineService
    {
        public static string Pode_Cadastrar_Url = "/rest/public/v1/execution/5f59799472c66c0032739f2b/execute/v16";

        public DesicionMachineService(HttpClient httpClient, ILogger<DesicionMachineService> logger) 
            : base(httpClient, logger)
        {
        }
    }
}
