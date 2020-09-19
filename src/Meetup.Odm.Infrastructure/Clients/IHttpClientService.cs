using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetup.Odm.Infrastructure.Clients
{
    public interface IHttpClientService<TResult>
    {
        Task<IList<TResult>> GetAllAsync(string url);
        Task<TResult> PostAsync<TData>(TData data, string url);
    }
}