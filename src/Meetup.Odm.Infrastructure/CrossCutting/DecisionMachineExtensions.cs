using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Meetup.Odm.Infrastructure.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace Meetup.Odm.Infrastructure.CrossCutting
{
    public static class DecisionMachineExtensions
    {
        public static IServiceCollection AddDecisionMachine(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DecisionMachineSettings>(configuration.GetSection(nameof(DecisionMachineSettings)).Get<DecisionMachineSettings>());

            services.AddHttpClient<IDesicionMachineService, DesicionMachineService>(
                client => {
                    client.BaseAddress = new Uri(configuration[$"{nameof(DecisionMachineSettings)}:Url"]);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", configuration[$"{nameof(DecisionMachineSettings)}:ApiKey"]);
                })
                .AddPolicyHandler(GetRetryPolicy());

            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
