using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Netricity.LinkChecker.Core
{
	public class RealHttpClient : IHttpClient
	{
		private HttpRequestHeaders _defaultRequestHeaders;

		public RealHttpClient()
		{
			//_defaultRequestHeaders = HttpRequestHeaders
		}

		public TimeSpan Timeout { get; set; }

		public HttpRequestHeaders DefaultRequestHeaders
		{
			get { throw new NotImplementedException(); }
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri)
		{
			throw new NotImplementedException();
		}
	}
}
