namespace Microsoft.AspNetCore.Components.Endpoints;
public abstract class DynamicComponentResolver<TState>
{
    public abstract ValueTask<ResolverResult> ResolveComponentAsync(HttpContext httpContext, RouteValueDictionary values, TState? state);

}