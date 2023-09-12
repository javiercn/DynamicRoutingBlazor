using DynamicRoutingBlazor.Client.Components;
using DynamicRoutingBlazor.Client.Components.Pages;
using Microsoft.AspNetCore.Components.Endpoints;

namespace DynamicRoutingBlazor.DynamicRouting;

public class CustomResolver : DynamicComponentResolver<object>
{
    public override ValueTask<ResolverResult> ResolveComponentAsync(
        HttpContext httpContext,
        RouteValueDictionary values,
        object? state)
    {
        return new ValueTask<ResolverResult>(new ResolverResult(typeof(App), typeof(Counter), new RouteValueDictionary()));
    }
}