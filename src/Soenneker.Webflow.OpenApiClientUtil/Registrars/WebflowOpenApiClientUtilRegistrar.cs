using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Webflow.HttpClients.Registrars;
using Soenneker.Webflow.OpenApiClientUtil.Abstract;

namespace Soenneker.Webflow.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class WebflowOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="WebflowOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddWebflowOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddWebflowOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IWebflowOpenApiClientUtil, WebflowOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="WebflowOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddWebflowOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddWebflowOpenApiHttpClientAsSingleton()
                .TryAddScoped<IWebflowOpenApiClientUtil, WebflowOpenApiClientUtil>();

        return services;
    }
}
