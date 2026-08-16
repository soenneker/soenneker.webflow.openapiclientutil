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
    ValueTask<WebflowOpenApiClient> Get(CancellationToken cancellationToken = default);
}
