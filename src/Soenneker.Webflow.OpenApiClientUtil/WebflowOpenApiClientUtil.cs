using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Webflow.HttpClients.Abstract;
using Soenneker.Webflow.OpenApiClientUtil.Abstract;
using Soenneker.Webflow.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Webflow.OpenApiClientUtil;

/// <inheritdoc cref="IWebflowOpenApiClientUtil" />
public sealed class WebflowOpenApiClientUtil : IWebflowOpenApiClientUtil
{
    private readonly AsyncSingleton<WebflowOpenApiClient> _client;

    public WebflowOpenApiClientUtil(IWebflowOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<WebflowOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

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
