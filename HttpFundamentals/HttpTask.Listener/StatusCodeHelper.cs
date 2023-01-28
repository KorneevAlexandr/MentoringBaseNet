using System.Net;

namespace HttpTask.Listener
{
	public static class StatusCodeHelper
	{
		public const string InformationPath = "Information";
		public const string SuccessPath = "Success";
		public const string RedirectionPath = "Redirection";
		public const string ClientErrorPath = "ClientError";
		public const string ServerErrorPath = "ServerError";

		public static string GetStatusCodesFromType(string requestName)
		{
			var enumItems = Enum.GetValues<HttpStatusCode>();
			var statusCodeSymbol = GetStatusCodeSymbol(requestName);

			return string.Join('\n', enumItems.Where(x => ((int)x).ToString().StartsWith(statusCodeSymbol)));
		}

		private static string GetStatusCodeSymbol(string requestName) =>
			requestName switch
			{
				InformationPath => "1",
				SuccessPath => "2",
				RedirectionPath => "3",
				ClientErrorPath => "4",
				ServerErrorPath => "5",
				_ => string.Empty,
			};
	}
}
