using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using System.Diagnostics.CodeAnalysis;

namespace DynamicRoutingBlazor.DynamicRouting;

public static class DynamicRoutingRazorComponentsEndpointRouteBuilderExtensions
{
    public static void MapDynamicRazorComponentEndpoints<TComponentResolver, TState>(
    this IEndpointRouteBuilder endpoints,
    [StringSyntax("Route")] string pattern,
    TState? state = default)
    where TComponentResolver : DynamicComponentResolver<TState>
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        endpoints.Map(
            pattern,
            context =>
            {
                throw new InvalidOperationException("This endpoint is not expected to be executed directly.");
            })
            .Add(b =>
            {
                ((RouteEndpointBuilder)b).Order = -1;
                b.Metadata.Add(DynamicRazorComponentEndpointResolverMetadata.Create<DynamicComponentResolver<TState>, TState>(state));
            });
    }
}
