using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetup.Odm.Application
{
    public interface IClienteValidation
    {
        Task<(bool sucesso, List<string> mensagens)> Validar(ClienteViewModel clienteViewModel);
    }
}
