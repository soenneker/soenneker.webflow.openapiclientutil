[![](https://img.shields.io/nuget/v/soenneker.webflow.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.webflow.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.webflow.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.webflow.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.webflow.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.webflow.openapiclientutil/)

# Soenneker.Webflow.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Webflow.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Webflow.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddWebflowOpenApiClientUtilAsSingleton();
```

Adds `WebflowOpenApiClientUtil` as a singleton service.

## What you get

- `IWebflowOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `WebflowOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `WebflowOpenApiClientUtilRegistrar.AddWebflowOpenApiClientUtilAsSingleton(services)` | Adds `WebflowOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `WebflowOpenApiClientUtilRegistrar.AddWebflowOpenApiClientUtilAsScoped(services)` | Adds `WebflowOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
