using System;
using Meetup.Odm.Infrastructure.Clients.Regras;

namespace Meetup.Odm.Infrastructure.Clients
{
    public interface IDesicionMachineService: IHttpClientService<PodeCadastrarRegra>
    {
    }
}
