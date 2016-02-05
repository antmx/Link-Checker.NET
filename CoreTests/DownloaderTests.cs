using System;
using System.Net;
using System.Net.Http;
using Moq;
using Netricity.Linkspector.Core;
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

         fakeResponseHandler.AddHtmlResponse(new Uri(href), HttpStatusCode.OK, "Foo content", 123456L);
			
			var url = new Uri2(href);
			var resource = new Resource(url, false);
         var downloader = new Downloader(fakeResponseHandler);

         //var toAwait = downloader.Download(resource);
         //await toAwait;

         await downloader.Download(resource);

         Assert.AreEqual("Foo content", resource.Content);
         Assert.AreEqual("text/html", resource.ContentType);
			Assert.AreEqual("utf-8", resource.ContentEncoding);
         Assert.AreEqual(123456L, resource.ContentLength);

         //var result = downloader.IsProtocolSupported;

         //Assert.IsTrue(result);
      }
	}
}
