using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;
namespace AdventureWorks.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
			builder.Services.AddHttpClient("AdventureAPI", (sp, cl) =>
            {
                cl.BaseAddress = new Uri(builder.Configuration.GetSection("AppSettings").GetSection("APiBase").Value);
				cl.EnableIntercept(sp);
            });

            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("AdventureAPI"));
            builder.Services.AddHttpClientInterceptor();
            builder.Services.AddScoped<HttpInterceptorService>();
            await builder.Build().RunAsync();
        }
    }
}
