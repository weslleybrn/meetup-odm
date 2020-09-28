using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Meetup.Odm.Teste.Infrastructure.Common
{
    public class ExecutarPodeCadastrarClienteModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("documento")]
        public string Documento { get; set; }

        [JsonProperty("idade")]
        public int Idade { get; set; }
    }

    public class ExecutarPodeCadastrarModel
    {
        public string Documento { get; set; }
        public int Idade { get; set; }
        public List<ExecutarPodeCadastrarClienteModel> Clientes { get; set; } = new List<ExecutarPodeCadastrarClienteModel>();
    }

    public static class ExecutarPodeCadastrarModelExtensions
    {
        public static ExecutarPodeCadastrarModel SeedClientes(this ExecutarPodeCadastrarModel ExecutarPodeCadastrarModel) {
            ExecutarPodeCadastrarModel
                .Clientes
                .AddRange(new List<ExecutarPodeCadastrarClienteModel> {
                    new ExecutarPodeCadastrarClienteModel
                    {     
                        Nome = "Mário Iago Pinto",
                        Documento="062.348.835-32",
                        Idade = 80
                    }, new ExecutarPodeCadastrarClienteModel
                    {     
                        Nome = "Severino Pedro Henrique Gustavo Carvalho",
                        Documento="297.271.542-04",
                        Idade = 65
                    }, new ExecutarPodeCadastrarClienteModel
                    {     
                        Nome = "Alexandre Kauê Vinicius dos Santos",
                        Documento="142.901.132-73",
                        Idade = 59
                    }});

            return ExecutarPodeCadastrarModel;
        }
    }
}
