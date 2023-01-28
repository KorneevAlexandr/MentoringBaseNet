using System.Net;
using HttpTask.Listener.Extensions;
using static HttpTask.Listener.StatusCodeHelper;

namespace HttpTask.Listener
{
	public class RequestHandler
	{
		public static async Task HandleAsync(HttpListenerContext httpContext)
		{
			try
			{
				var localPath = httpContext.GetLocalPath();
				string responseContent = string.Empty;	

				if (localPath.StartsWith("Get"))
				{
					responseContent = localPath[3..];
				}
				else if (localPath.In(InformationPath, SuccessPath, RedirectionPath, ClientErrorPath, ServerErrorPath))
				{
					responseContent = GetStatusCodesFromType(localPath);
				}

				using var responseWriter = new ResponseWriter(httpContext.Response);
				await responseWriter.WriteAsync(responseContent);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
