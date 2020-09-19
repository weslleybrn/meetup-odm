using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Meetup.Odm.Teste.Infrastructure.Common;

namespace Meetup.Odm.Teste.Infrastructure.Spec
{
    public class HttpClientServiceSpec
    {
        private IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            
            services.AddHttpClient<IAuthorClientService, AuthorClientService>(
                client => {
                    client.BaseAddress = new Uri("https://fakerestapi.azurewebsites.net");
                });
            
            return services.BuildServiceProvider();
        }

        [Fact]
        public async Task DeveExecutarComandoGetAllAsync() 
        {
            //given
            var authorClientService = this.BuildServiceProvider()
                                          .GetRequiredService<IAuthorClientService>();

            //when
            var response = await authorClientService.GetAllAsync("/api/Authors");
            
            //then
            authorClientService.Should().NotBeNull();
            response.Count.Should().NotBe(0);
        }

        [Fact]
        public async Task DeveExecutarComandoPostAsync()
        {
             //given
            var authorClientService = this.BuildServiceProvider()
                                          .GetRequiredService<IAuthorClientService>();
            AuthorModel data = new AuthorModel();

            //when
            var response = await authorClientService.PostAsync<AuthorModel>(data, "/api/Authors");
            
            //then
            authorClientService.Should().NotBeNull();
            response.Should().NotBeNull();
            response.Should().BeOfType<AuthorModel>();
            response.ID.Should().Be(0);
            response.IDBook.Should().Be(0);
            response.FirstName.Should().BeNull();
            response.LastName.Should().BeNull();
        }

    }
}