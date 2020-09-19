using System;
using System.Collections.Generic;

namespace Meetup.Odm.Teste.Infrastructure.Common
{
    public class ExecutarPodeCadastrarClienteModel
    {
        //Falar sobre case sensitive
        public string nome { get; set; }
        public string documento { get; set; }
        public int idade { get; set; }
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
                        nome = "Mário Iago Pinto",
                        documento="062.348.835-32",
                        idade = 80
                    }, new ExecutarPodeCadastrarClienteModel
                    {     
                        nome = "Severino Pedro Henrique Gustavo Carvalho",
                        documento="297.271.542-04",
                        idade = 65
                    }, new ExecutarPodeCadastrarClienteModel
                    {     
                        nome = "Alexandre Kauê Vinicius dos Santos",
                        documento="142.901.132-73",
                        idade = 59
                    }});

            return ExecutarPodeCadastrarModel;
        }
    }
}
