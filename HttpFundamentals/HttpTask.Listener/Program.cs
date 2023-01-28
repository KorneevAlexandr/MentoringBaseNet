using HttpTask.Listener;
using System.Net;

var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8888/");

try
{
	listener.Start();

	while (true)
	{
		var httpContext = await listener.GetContextAsync();
		RequestHandler.HandleAsync(httpContext);
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
