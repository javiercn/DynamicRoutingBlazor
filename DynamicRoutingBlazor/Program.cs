using DynamicRoutingBlazor.Client.Components;
using DynamicRoutingBlazor.DynamicRouting;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddServerComponents()
    .AddWebAssemblyComponents();

builder.Services.TryAddEnumerable(
    ServiceDescriptor.Singleton<MatcherPolicy, DynamicRazorComponentEndpointMatcherPolicy>());
builder.Services.AddSingleton<DynamicComponentResolver<object>, CustomResolver>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.MapRazorComponents<App>()
    .AddServerRenderMode()
    .AddWebAssemblyRenderMode();

app.MapDynamicRazorComponentEndpoints<CustomResolver, object>("{**path:nonfile}", null);

app.Run();