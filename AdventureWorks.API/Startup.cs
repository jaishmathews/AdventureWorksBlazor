using AdventureWorks.API.Middleware;
using AdventureWorks.Business.Interface;
using AdventureWorks.Business.Repositories;
using AdventureWorks.DataAccess.Models;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AdventureWorks.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));

			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
			});

			services.AddVersionedApiExplorer(options =>
			{
				// add the versioned api explorer, which also adds IApiVersionDescriptionProvider service  
				// note: the specified format code will format the version as "'v'major[.minor][-status]"  
				options.GroupNameFormat = "'v'VVV";

				// note: this option is only necessary when versioning by url segment. the SubstitutionFormat  
				// can also be used to control the format of the API version in route templates  
				options.SubstituteApiVersionInUrl = true;
			});
			services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
			services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddControllers();
			services.AddDbContext<AdventureWorksLT2019Context>();
			// Register the IOptions object
			services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
			services.Register();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
			IApiVersionDescriptionProvider provider, ILogger<Startup> logger)
		{
			if (env.IsDevelopment())
			{
				app.UseExceptionHandler("/error-local-development");
			}

			app.ConfigureExceptionHandler(logger);

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(
			options =>
			{
				// build a swagger endpoint for each discovered API version  
				foreach (var description in provider.ApiVersionDescriptions)
				{
					options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
				}
			});
			string[] corsOriginUrls = Configuration.GetSection("AppSettings").GetSection("CorsOriginUrls").Value.Split(",");
			app.UseCors(policy =>
			//policy.WithOrigins("https://localhost:5002", "https://localhost:44397", "https://localhost:44372")
			policy.WithOrigins(corsOriginUrls)
		   .AllowAnyMethod()
		   .WithHeaders(HeaderNames.ContentType)); ;

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
