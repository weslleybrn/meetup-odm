using System;
using Meetup.Odm.Infrastructure.Clients;

namespace Meetup.Odm.Teste.Infrastructure.Common
{
    public interface IAuthorClientService : IHttpClientService<AuthorModel>
    {

    }
}
