using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Netricity.Linkspector.Core
{
	public interface IHttpClient
	{
		TimeSpan Timeout { get; set; }

		HttpRequestHeaders DefaultRequestHeaders { get; }

		Task<HttpResponseMessage> GetAsync(string requestUri);


	}
}
