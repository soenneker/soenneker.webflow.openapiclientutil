using Soenneker.Webflow.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Webflow.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IWebflowOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured webflow OpenAPI Client used by the Webflow OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested webflow OpenAPI Client.</returns>
    ValueTask<WebflowOpenApiClient> Get(CancellationToken cancellationToken = default);
}
