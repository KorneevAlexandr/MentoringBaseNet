using System.Net;

namespace HttpTask.Listener.Extensions;

public static class HttpContextExtensions
{
	public static string GetLocalPath(this HttpListenerContext httpContext) => httpContext.Request.RawUrl[1..];
}
