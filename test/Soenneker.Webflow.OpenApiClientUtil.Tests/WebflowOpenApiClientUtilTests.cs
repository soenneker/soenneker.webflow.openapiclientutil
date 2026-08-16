using Soenneker.Webflow.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Webflow.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class WebflowOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IWebflowOpenApiClientUtil _openapiclientutil;

    public WebflowOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IWebflowOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
