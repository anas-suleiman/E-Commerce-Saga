using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Hiermit wird der HttpClient an die HttpClientFactory registriert
        /// Zusätzlich werden hier die Polly Policies registriert
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="timeOutInSeconds">The time out in seconds.</param>
        /// <param name="useRetryPolicy">if set to <c>true</c> [use retry policy].</param>
        /// <returns>
        /// IHttpClientBuilder
        /// </returns>
        public static IHttpClientBuilder AddSdkClient<TClient, TImplementation>(this IServiceCollection services, int timeOutInSeconds = 30, bool useRetryPolicy = false)
            where TClient : class
            where TImplementation : class, TClient
        {

            // Overall timeout across all tries
            IHttpClientBuilder httpClientBuilder = services.AddHttpClient<TClient, TImplementation>(o => o.Timeout = TimeSpan.FromSeconds(timeOutInSeconds));

            return httpClientBuilder;
        }
    }
}