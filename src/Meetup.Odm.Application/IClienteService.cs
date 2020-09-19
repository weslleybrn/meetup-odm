using System.Threading.Tasks;

namespace Meetup.Odm.Application
{
    public interface IClienteService
    {
        void CadastrarCliente(ClienteViewModel clienteViewModel);        
    }
}
