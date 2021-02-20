using AdventureWorks.UIServer.Utility.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdventureWorks.UIServer.Utility
{
	public class DataAccessManager : IDataAccessManager
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger<DataAccessManager> _logger;

		public DataAccessManager(HttpClient httpClient, ILogger<DataAccessManager> logger)
		{
			_httpClient = httpClient;
			_logger = logger;
		}

		public async Task<T> GetAsync<T>(string apiRoute)
		{
			var response = await _httpClient.GetFromJsonAsync<T>(apiRoute);
			if (response is not null)
			{
				return response;
			}
			return default(T);
		}

		public async Task<bool> PostAsync<T>(string apiRoute, T postObject)
		{
			var response = await _httpClient.PostAsJsonAsync(apiRoute, postObject);
			return response.IsSuccessStatusCode;
		}

	}
}
