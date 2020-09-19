using System;
using System.Threading.Tasks;

namespace Meetup.Odm.Application
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteValidation _clienteValidation;

        public ClienteService(IClienteValidation clienteValidation)
        {
            _clienteValidation = clienteValidation;
        }

        public void CadastrarCliente(ClienteViewModel clienteViewModel)
        {
            var validacao = _clienteValidation.Validar(clienteViewModel).GetAwaiter().GetResult();
            if(!validacao.sucesso)
                throw new Exception(string.Join(@"\r\n,", validacao.mensagens));


            //Daqui pra baixo é o processo normal para persistência
        }
    }
}
