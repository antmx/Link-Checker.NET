using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreTests
{
	class FakeResponseHandler : DelegatingHandler
	{
		private readonly Dictionary<Uri, HttpResponseMessage> _fakeResponses = new Dictionary<Uri, HttpResponseMessage>();

		public void AddResponse(Uri uri, HttpResponseMessage responseMessage)
		{
			_fakeResponses.Add(uri, responseMessage);
		}

		protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (_fakeResponses.ContainsKey(request.RequestUri))
			{
				var responseMsg = _fakeResponses[request.RequestUri];
				responseMsg.Content = new StringContent("", null, "text/html");
				responseMsg.Content.Headers.ContentEncoding.Add("utf-8");
				
				return responseMsg;
			}
			else
			{
				return new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request };
			}

		}
	}
}
