using System;
using System.Net;
using System.Net.Http;
using Moq;
using Netricity.LinkChecker.Core;
using NUnit;
using NUnit.Framework;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoreTests
{
	[TestFixture]
	[Category("Downloader")]
	public class DownloaderTests
	{
		[Test]
		public void Download_()
		{

		}

		//[Test]
		//public void IsProtocolSupported_ReturnsTrue_ForSupportedProtocol()
		//{
		//	var downloader = new Downloader("http://www.foo.com/");

		//	var result = downloader.IsProtocolSupported;

		//	Assert.IsTrue(result);
		//}

		//[Test]
		//public void IsProtocolSupported_ReturnsFalse_ForUnsupportedProtocol()
		//{
		//	var downloader = new Downloader("ftp://www.foo.com/");

		//	var result = downloader.IsProtocolSupported;

		//	Assert.IsFalse(result);
		//}

		[Test]
		public async Task Download_ReturnsFalse_ForUnsupportedProtocol()
		{
			var href = "http://example.org/test";
			var fakeResponseHandler = new FakeResponseHandler();

			fakeResponseHandler.AddResponse(
				new Uri(href),
				new HttpResponseMessage(HttpStatusCode.OK));
			
			var url = new Uri2(href);
			var resource = new Resource(url, false);
			var downloader = new Downloader(fakeResponseHandler, resource);

			var toAwait = new Task(downloader.Download);

			await toAwait;

			Assert.AreEqual("text/html", resource.ContentType);
			Assert.AreEqual("utf-8", resource.ContentEncoding);

			//var result = downloader.IsProtocolSupported;

			//Assert.IsTrue(result);
		}
	}
}
