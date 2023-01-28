using System.Net;
using System.Text;

namespace HttpTask.Listener
{
	public sealed class ResponseWriter : IDisposable
	{
		private HttpListenerResponse _response;

		public ResponseWriter(HttpListenerResponse response)
		{
			_response = response;
		}

		public async Task WriteAsync(string content)
		{
			var responseData = Encoding.Unicode.GetBytes(content);
			_response.ContentLength64 = responseData.Length;

			using var outputStream = _response.OutputStream;

			await outputStream.WriteAsync(responseData);
			await outputStream.FlushAsync();
		}

		public void Dispose()
		{
			_response.Close();
		}
	}
}
