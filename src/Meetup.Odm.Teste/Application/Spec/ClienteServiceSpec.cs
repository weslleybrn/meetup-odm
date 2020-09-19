using System;
using System.Threading.Tasks;
using FluentAssertions;
using Meetup.Odm.Application;
using Meetup.Odm.Infrastructure.CrossCutting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Meetup.Odm.Teste.Application.Spec
{
    public class ClienteServiceSpec
    {
        
        private IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"Infrastructure\Settings\appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
             
            services.AddDecisionMachine(configuration);
            services.AddScoped<IClienteValidation, ClienteValidation>();
            services.AddScoped<IClienteService, ClienteService>();

            return services.BuildServiceProvider();
        }
        
        [Fact]
        public Task DeveCadastrarClienteService()
        {
            //given
            var clienteService = this.BuildServiceProvider().GetRequiredService<IClienteService>();
            
            var clienteViewModel = new ClienteViewModel();
            clienteViewModel.Nome = "Marcos Vinicius Enzo Pereira";
            clienteViewModel.DataNascimento = DateTime.Parse("15/01/1946");
            clienteViewModel.Documento = "498.800.248-93";
            
            //when
            Action execute = () =>  clienteService.CadastrarCliente(clienteViewModel);
            
            //then
            execute.Should().NotThrow<Exception>();

            return Task.CompletedTask;
        }

        [Fact]
        public Task NaoDeveCadastrarClienteService()
        {
            //given
            var clienteService = this.BuildServiceProvider().GetRequiredService<IClienteService>();
            
            var clienteViewModel = new ClienteViewModel();
            clienteViewModel.Nome = "Mário Iago Pinto";
            clienteViewModel.DataNascimento = DateTime.Parse("15/01/1991");
            clienteViewModel.Documento = "062.348.835-32";
            
            //when
            Action execute = () =>  clienteService.CadastrarCliente(clienteViewModel);
            
            //then
            execute.Should()
                   .Throw<Exception>().Which.Message
                   .Should()
                   .Contain("não pode");
            
            return Task.CompletedTask;
        }
    }
}
