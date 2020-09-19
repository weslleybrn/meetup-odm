using System.Text.RegularExpressions;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Meetup.Odm.Infrastructure.Clients;
using Meetup.Odm.Infrastructure.CrossCutting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Meetup.Odm.Teste.Infrastructure.Spec
{
    public class DecisionMachineExtensionsSpec
    {    
        [Fact]
        public Task DeveConfigurarDesicionMachine()
        {
            //given 
            var services = new ServiceCollection();
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"Infrastructure\Settings\appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
             
            //Falar sobre o configuration
            services.AddDecisionMachine(configuration);
            
            var provider = services.BuildServiceProvider();

            //when
            var desicionMachineService = provider.GetRequiredService<IDesicionMachineService>();

            //then
            desicionMachineService.Should().NotBeNull();

            return Task.CompletedTask;
        }
    }
}
