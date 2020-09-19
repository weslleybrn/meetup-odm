using System.Text.RegularExpressions;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Meetup.Odm.Infrastructure.Clients;
using Meetup.Odm.Infrastructure.Clients.Regras;
using Meetup.Odm.Teste.Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Meetup.Odm.Teste.Infrastructure.Spec
{
    public class DesicionMachineServiceSpec
    {
        
        private IServiceProvider BuildServiceProvider()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"Infrastructure\Settings\appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            var services = new ServiceCollection();
            
            //Falar sobre o configuration
            services.AddHttpClient<IDesicionMachineService, DesicionMachineService>(
                client => {
                    client.BaseAddress = new Uri(configuration["DecisionMachine:Url"]);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", configuration["DecisionMachine:ApiKey"]);
                });
            
            return services.BuildServiceProvider();
        }

        [Fact]
        public async Task DeveExecutarComandoPostAsync()
        {
             //given
            var desicionMachineService = this.BuildServiceProvider()
                                             .GetRequiredService<IDesicionMachineService>();
            var data = new ExecutarPodeCadastrarModel();
            data.Documento = "604.926.888-69";
            data.Idade = 50;

            data.SeedClientes();

            //when
            var response = await desicionMachineService.PostAsync<ExecutarPodeCadastrarModel>(data, DesicionMachineService.Pode_Cadastrar_Url);
            
            //then
            desicionMachineService.Should().NotBeNull();
            response.Should().NotBeNull();
            response.Should().BeOfType<PodeCadastrarRegra>();
        }


        [Fact]
        public async Task DeveAprovarCadastro()
        {
             //given
            var desicionMachineService = this.BuildServiceProvider()
                                          .GetRequiredService<IDesicionMachineService>();
            ExecutarPodeCadastrarModel data = new ExecutarPodeCadastrarModel();
            data.Documento = "604.926.888-69";
            data.Idade = 50;

            data.SeedClientes();

            //when
            var response = await desicionMachineService.PostAsync<ExecutarPodeCadastrarModel>(data, DesicionMachineService.Pode_Cadastrar_Url);
            
            //then
            desicionMachineService.Should().NotBeNull();
            response.Should().NotBeNull();
            response.Should().BeOfType<PodeCadastrarRegra>();
            response.__DecisionID__.Should().NotBeEmpty();
            response.Pode_Cadastrar.Should().NotBeNull();
            response.Pode_Cadastrar.sucesso.Should().BeTrue();
            response.Pode_Cadastrar.mensagens.Any().Should().BeTrue();
            response.Pode_Cadastrar.mensagens.Any(m => m.ToLower().Contains("pode ser")).Should().BeTrue();
        }

        [Fact]
        public async Task DeveNegarCadastro()
        {
             //given
            var desicionMachineService = this.BuildServiceProvider()
                                          .GetRequiredService<IDesicionMachineService>();
            ExecutarPodeCadastrarModel data = new ExecutarPodeCadastrarModel();
            data.Documento = "062.348.835-32";
            data.Idade = 48;

            data.SeedClientes();

            //when
            var response = await desicionMachineService.PostAsync<ExecutarPodeCadastrarModel>(data, DesicionMachineService.Pode_Cadastrar_Url);
            
            //then
            desicionMachineService.Should().NotBeNull();
            response.Should().NotBeNull();
            response.Should().BeOfType<PodeCadastrarRegra>();
            response.__DecisionID__.Should().NotBeEmpty();
            response.Pode_Cadastrar.Should().NotBeNull();
            response.Pode_Cadastrar.sucesso.Should().BeFalse();
            response.Pode_Cadastrar.mensagens.Any().Should().BeTrue();
            response.Pode_Cadastrar.mensagens.Any(m => m.ToLower().Contains("não")).Should().BeTrue();
        }

    }
}