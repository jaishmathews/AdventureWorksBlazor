using AdventureWorks.UIServer.Data;
using AdventureWorks.UIServer.Utility;
using AdventureWorks.UIServer.Utility.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using Toolbelt.Blazor.Extensions.DependencyInjection;
namespace AdventureWorks.UIServer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));
			services.AddHttpClient("AdventureAPI", (sp, cl) =>
			{
				cl.BaseAddress = new Uri(Configuration.GetSection("AppSettings").GetSection("APiBase").Value);
				cl.EnableIntercept(sp);
			});
			services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("AdventureAPI"));
			services.AddHttpClientInterceptor();
			services.AddScoped<HttpInterceptorService>();
			services.AddScoped<IDataAccessManager, DataAccessManager>();
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddSingleton<WeatherForecastService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
