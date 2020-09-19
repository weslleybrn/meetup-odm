using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meetup.Odm.Infrastructure.Clients;
using Meetup.Odm.Infrastructure.Clients.Regras;

namespace Meetup.Odm.Application
{
    public class ClienteValidation : IClienteValidation
    {
        private readonly IDesicionMachineService _desicionMachineService;

        public ClienteValidation(IDesicionMachineService desicionMachineService)
        {
            _desicionMachineService = desicionMachineService;
        }

        public async Task<(bool sucesso, List<string> mensagens)> Validar(ClienteViewModel clienteViewModel)
        {
            //Falar sobre automapper
             var data = new ClienteValidateModel();
            data.Documento = clienteViewModel.Documento;
            data.Idade = DateTime.Now.Year - clienteViewModel.DataNascimento.Year;

            //Recupera da base de dados
            //Recupera de um cache
            data.Clientes.AddRange(new List<ClienteValidateModelList> {
                new ClienteValidateModelList
                {     
                    nome = "Mário Iago Pinto",
                    documento="062.348.835-32",
                    idade = 80
                }, new ClienteValidateModelList
                {     
                    nome = "Severino Pedro Henrique Gustavo Carvalho",
                    documento="297.271.542-04",
                    idade = 65
                }, new ClienteValidateModelList
                {     
                    nome = "Alexandre Kauê Vinicius dos Santos",
                    documento="142.901.132-73",
                    idade = 59
                }});

            //Executa a regra
            var response = await _desicionMachineService.PostAsync<ClienteValidateModel>(data, DesicionMachineService.Pode_Cadastrar_Url);

            return (response.Pode_Cadastrar.sucesso, response.Pode_Cadastrar.mensagens);
        }
    }
}
