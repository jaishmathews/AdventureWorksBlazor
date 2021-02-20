using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Toolbelt.Blazor;

namespace AdventureWorks.UI
{
	public class HttpInterceptorService
	{
		private readonly ILogger<HttpInterceptorService> _logger;
		private readonly HttpClientInterceptor _interceptor;
		private readonly NavigationManager _navManager;

		public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager, ILogger<HttpInterceptorService> logger)
		{
			_interceptor = interceptor;
			_navManager = navManager;
			_logger = logger;
		}

		public void RegisterEvent() => _interceptor.AfterSend += InterceptResponse;

		private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
		{
			HttpResponseMessage responseMessage = e.Response;
			if (responseMessage != null && !responseMessage.IsSuccessStatusCode)
			{
				var responseStatusCode = e.Response.StatusCode;
				_logger.LogError(responseMessage.ToString());
				_navManager.NavigateTo($"/http-response/{(int)responseStatusCode}");
			}
			_logger.LogInformation("API Call completed..");
		}

		public void DisposeEvent() => _interceptor.AfterSend -= InterceptResponse;
	}
}
