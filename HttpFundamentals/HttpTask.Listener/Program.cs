using System.Net;

namespace HttpTask.Listener;

class Program
{
	private const string SiteUrl = "http://localhost:8888/";

	public static async Task Main(string[] args)
	{
		var listener = new HttpListener();
		listener.Prefixes.Add(SiteUrl);

		try
		{
			listener.Start();

			while (true)
			{
				var httpContext = await listener.GetContextAsync();
				await RequestHandler.HandleAsync(httpContext);
			}
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(ex.Message);
		}
		finally
		{
			listener.Stop();
			listener.Close();
		}
	}
}
