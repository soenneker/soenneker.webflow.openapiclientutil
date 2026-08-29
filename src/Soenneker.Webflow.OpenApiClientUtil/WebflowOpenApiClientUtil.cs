using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Webflow.HttpClients.Abstract;
using Soenneker.Webflow.OpenApiClientUtil.Abstract;
using Soenneker.Webflow.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Webflow.OpenApiClientUtil;

/// <inheritdoc cref="IWebflowOpenApiClientUtil"/>
public sealed class WebflowOpenApiClientUtil : IWebflowOpenApiClientUtil
{
    private readonly AsyncSingleton<WebflowOpenApiClient> _client;

    public WebflowOpenApiClientUtil(IWebflowOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<WebflowOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Webflow:AccessToken");
            string authHeaderName = configuration["Webflow:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["Webflow:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new WebflowOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<WebflowOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
