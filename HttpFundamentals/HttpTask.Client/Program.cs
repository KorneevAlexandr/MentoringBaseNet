namespace HttpTask.Client;

class Program
{
	private const string InformationPath = "Information";
	private const string SuccessPath = "Success";
	private const string RedirectionPath = "Redirection";
	private const string ClientErrorPath = "ClientError";
	private const string ServerErrorPath = "ServerError";

	private static HttpClient _httpClient;

	public async static Task Main(string[] args)
	{
		_httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:8888") };

		await GetMyName("Alex"); // Task 1

		await StatusCodesRequests(); // Task 2
	}

	private static async Task GetMyName(string name)
	{
		Console.WriteLine("\tTask 1 (GetMyName implementation)\n");
		var response = await SendRequestAsync(new HttpRequestMessage(HttpMethod.Get, $"Get{name}"));
		Console.WriteLine(response + "\n");
	}

	private static async Task StatusCodesRequests()
	{
		Console.WriteLine("\tTask 2 (StatusCode receiving)\n");
		var requestNames = new string[] { InformationPath, SuccessPath, RedirectionPath, ClientErrorPath, ServerErrorPath };

		foreach (var requestName in requestNames)
		{
			Console.WriteLine($" *** {requestName} status codes ***");
			var response = await SendRequestAsync(new HttpRequestMessage(HttpMethod.Get, requestName));
			Console.WriteLine(response + "\n");
		}
	}

	private static async Task<string> SendRequestAsync(HttpRequestMessage requestMessage)
	{
		var response = await _httpClient.SendAsync(requestMessage);
		return await response.Content.ReadAsStringAsync();
	}
}


