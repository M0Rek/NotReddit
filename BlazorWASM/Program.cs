using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using BlazorWasm.Auth;
using BlazorWASM.Services.ClientImplementations;
using BlazorWASM.Services.ClientInterfaces;
using Domain.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using AuthService = BlazorWASM.Services.ClientImplementations.AuthService;
using IAuthService = BlazorWASM.Services.ClientInterfaces.IAuthService;
using IPostService = BlazorWASM.Services.ClientInterfaces.IPostService;
using PostService = BlazorWASM.Services.ClientImplementations.PostService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new System.Net.Http.HttpClient { BaseAddress = new Uri("https://localhost:7233") });
builder.Services.AddMudServices();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IAuthService, AuthService>();
AuthorizationPolicies.AddPolicies(builder.Services);
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();