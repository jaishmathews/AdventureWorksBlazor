using Microsoft.AspNetCore.Components;
using System.Net;

namespace AdventureWorks.UI.Pages
{
	public partial class HttpResponse
	{
		[Inject]
		public NavigationManager NavigationManager { get; set; }
		[Parameter]
		public int ResponseStatusCode { get; set; }

		public string HttpMessage { get; set; }
		public void NavigateToHome()
		{
			NavigationManager.NavigateTo("/");
		}

		protected override void OnAfterRender(bool firstRender)
		{
			base.OnAfterRender(firstRender);
		}

		protected override void OnInitialized()
		{
			HttpStatusCode httpStatusCode = (HttpStatusCode)ResponseStatusCode;
			HttpMessage = httpStatusCode switch
			{
				HttpStatusCode.NotFound => "We are sorry, but we couldn't find the page you are looking for!!!.",
				HttpStatusCode.Unauthorized => "User is not authorized",
				_ => "Something went wrong, please contact Administrator",
			};
		}
	}
}
