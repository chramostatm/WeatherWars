using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GeolocationService = AspNetMonsters.Blazor.Geolocation.LocationService;
using Blazored.LocalStorage;
using WeatherClientLib;
using Microsoft.Extensions.Configuration;
using WeatherWars.Client.Shared;

namespace WeatherWars.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped<IWeatherForecastService, HttpWeatherForecastService>();
            builder.Services.AddScoped<GeolocationService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<PinnedLocationsService>();
            builder.Services.AddScoped<IConfiguration, LocalStorageConfiguration>();
            await builder.Build().RunAsync();
        }
    }
}
