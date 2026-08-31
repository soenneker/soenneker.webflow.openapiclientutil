using Soenneker.Webflow.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Webflow.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Webflow OpenAPI client backed by authenticated transport.
/// </summary>
public interface IWebflowOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached client.</returns>
    ValueTask<WebflowOpenApiClient> Get(CancellationToken cancellationToken = default);
}
