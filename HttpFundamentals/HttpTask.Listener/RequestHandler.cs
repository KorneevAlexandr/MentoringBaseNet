using System.Net;
using HttpTask.Listener.Extensions;
using HttpTask.Listener.Utils;
using static HttpTask.Listener.Utils.StatusCodeHelper;

namespace HttpTask.Listener;

public class RequestHandler
{
	public const string MyName = "Aliaksandr";

	private const string MyNameMethodName = "MyName";
	private const string MyNameByHeaderMethodName = "MyNameByHeader";
	private const string MyNameByCookiesMethodName = "MyNameByCookies";
	private const string CookieAndHeaderName = "MyName";

	public static async Task HandleAsync(HttpListenerContext httpContext)
	{
		try
		{
			var localPath = httpContext.GetLocalPath();
			string responseContent = string.Empty;

			if (localPath.Equals(MyNameMethodName))
			{
				responseContent = MyName;
			}
			else if (localPath.In(InformationPath, SuccessPath, RedirectionPath, ClientErrorPath, ServerErrorPath))
			{
				responseContent = GetStatusCodesFromType(localPath);
			}
			else if (localPath.Equals(MyNameByHeaderMethodName))
			{
				httpContext.Response.AddHeader(CookieAndHeaderName, MyName);
			}
			else if (localPath.Equals(MyNameByCookiesMethodName))
			{
				httpContext.Response.SetCookie(new Cookie(CookieAndHeaderName, MyName));
			}
			else
			{
				responseContent = "Server does not have this method.";
				httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
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
