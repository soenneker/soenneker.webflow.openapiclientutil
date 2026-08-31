[![](https://img.shields.io/nuget/v/soenneker.webflow.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.webflow.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.webflow.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.webflow.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.webflow.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.webflow.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.webflow.openapiclientutil/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.webflow.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Webflow.OpenApiClientUtil

Provides a cached `WebflowOpenApiClient` backed by an authenticated Webflow Data API v2 transport.

## Installation

```bash
dotnet add package Soenneker.Webflow.OpenApiClientUtil
```

## Configuration

```json
{
  "Webflow": {
    "AccessToken": "your-webflow-access-token"
  }
}
```

The token may be a site token or an OAuth access token and must include the scopes required by the operations being called.

## Registration

```csharp
using Soenneker.Webflow.OpenApiClientUtil.Registrars;

services.AddWebflowOpenApiClientUtilAsScoped();
```

Use `AddWebflowOpenApiClientUtilAsSingleton()` to share the generated-client wrapper too. Both registrations borrow the singleton Webflow HTTP provider; disposing a scoped wrapper does not remove or dispose that shared transport.

## Usage

```csharp
using Soenneker.Webflow.OpenApiClient;
using Soenneker.Webflow.OpenApiClient.Models;
using Soenneker.Webflow.OpenApiClientUtil.Abstract;

public sealed class SiteReader
{
    private readonly IWebflowOpenApiClientUtil _clients;

    public SiteReader(IWebflowOpenApiClientUtil clients)
    {
        _clients = clients;
    }

    public async ValueTask<ListSites200Response?> GetSites(
        CancellationToken cancellationToken)
    {
        WebflowOpenApiClient client = await _clients.Get(cancellationToken);
        return await client.Sites.GetAsync(cancellationToken: cancellationToken);
    }
}
```

Listing sites requires the `sites:read` scope. Webflow and transport failures propagate through Kiota exceptions.
