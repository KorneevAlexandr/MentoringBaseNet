namespace HttpTask.Client;

class Program
{
	private const string SiteUrl = "http://localhost:8888";

	private const string InformationPath = "Information";
	private const string SuccessPath = "Success";
	private const string RedirectionPath = "Redirection";
	private const string ClientErrorPath = "ClientError";
	private const string ServerErrorPath = "ServerError";

	private static HttpClient _httpClient;

	public async static Task Main(string[] args)
	{
		_httpClient = new HttpClient { BaseAddress = new Uri(SiteUrl) };

		await GetMyName(); // Task 1

		await StatusCodesRequests(); // Task 2

		await GetMyNameByHeader(); // Task 3

		await GetMyNameByCookies(); // Task 4
	}

	private static async Task GetMyName()
	{
		Console.WriteLine("\tTask 1 (GetMyName implementation)\n");

		var response = await _httpClient.GetAsync("MyName");
		var content = await response.Content.ReadAsStringAsync();

		Console.WriteLine(content + "\n");
	}

	private static async Task StatusCodesRequests()
	{
		Console.WriteLine("\tTask 2 (StatusCode receiving)\n");
		var requestNames = new string[] { InformationPath, SuccessPath, RedirectionPath, ClientErrorPath, ServerErrorPath };

		foreach (var requestName in requestNames)
		{
			Console.WriteLine($" *** {requestName} status code ***");

			var response = await _httpClient.GetAsync(requestName);
			var content = await response.Content.ReadAsStringAsync();

			Console.WriteLine(content + "\n");
		}
	}

	private static async Task GetMyNameByHeader()
	{
		Console.WriteLine("\tTask 3 (GetMyNameByHeader implementation)\n");

		var response = await _httpClient.GetAsync("MyNameByHeader");
		var headerValue = response.Headers.GetValues("MyName");

		Console.WriteLine(headerValue.First() + "\n");
	}

	private static async Task GetMyNameByCookies()
	{
		Console.WriteLine("\tTask 4 (GetMyNameByCookies implementation)\n");

		var response = await _httpClient.GetAsync("MyNameByCookies");

		foreach (var cookieHeader in response.Headers.GetValues("Set-Cookie"))
		{
			if (cookieHeader.Contains("MyName"))
			{
				Console.WriteLine(cookieHeader[7..]);
			}
		}
	}
}


