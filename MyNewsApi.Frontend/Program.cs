using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyNewsApi.Frontend;
using MyNewsApi.Frontend.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// 1) Registra i servizi di MudBlazor
builder.Services.AddMudServices();

// 2) Registra Blazored LocalStorage (usato per salvare il JWT)
builder.Services.AddBlazoredLocalStorage();

// 3) Registra il DelegatingHandler per l'autenticazione
builder.Services.AddScoped<AuthenticationHeaderHandler>();

// 4) Registra un HttpClient che usa il DelegatingHandler
builder.Services.AddScoped(sp =>
{
    // Recupera il nostro handler e imposta l'inner handler
    var authHandler = sp.GetRequiredService<AuthenticationHeaderHandler>();
    authHandler.InnerHandler = new HttpClientHandler();

    // Imposta il BaseAddress dell'HttpClient, ad esempio quello del backend
    return new HttpClient(authHandler)
    {
        BaseAddress = new Uri("https://localhost:5001/")
    };
});

// 5) Registra i tuoi servizi personalizzati
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<INewsService, NewsService>();

// Avvia l'applicazione (una sola volta)
await builder.Build().RunAsync();

/// <summary>
/// Handler che legge il token da LocalStorage e lo aggiunge come Bearer Authorization a ogni richiesta.
/// </summary>
public class AuthenticationHeaderHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorage;

    public AuthenticationHeaderHandler(ILocalStorageService localStorage)
        => _localStorage = localStorage;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}