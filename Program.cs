using AppRaypal_Blazor.API;
using AppRaypal_Blazor.Helpers;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppRaypal_Blazor
{
    public class Program
    {
        public static Models.clsUsuarios miUsuarioLogueado { get; set; }

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            ConfigureServices(builder.Services);

            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredSessionStorage(config =>
                 config.JsonSerializerOptions.WriteIndented = true
             );

            await builder.Build().RunAsync(); 
        }


        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddScoped<IMostrarMensajes, MostrarMensajes>();
            services.AddScoped<IApi, Servicio>();
            services.AddAuthorizationCore();

            services.AddAuthorizationCore();
            services.AddScoped<CustomAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(op =>
            op.GetRequiredService<CustomAuthenticationStateProvider>());




        }
    }
}
