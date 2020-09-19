using System;
using System.Net.Http;
using Meetup.Odm.Infrastructure.Clients;
using Microsoft.Extensions.Logging;

namespace Meetup.Odm.Teste.Infrastructure.Common
{
    public class AuthorClientService : HttpClientService<AuthorModel>, IAuthorClientService
    {
        public AuthorClientService(HttpClient httpClient, ILogger<AuthorClientService> logger) 
            : base(httpClient, logger)
        {
        }
    }
}
