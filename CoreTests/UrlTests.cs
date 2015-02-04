using System;
using Moq;
using Netricity.LinkChecker.Core;
using NUnit;
using NUnit.Framework;

namespace CoreTests
{
	[TestFixture]
	public class UrlTests
	{
		[Test]
		[Category("Url")]
		public void AllProperties_AreSet_WhenValidUrlPassedToCtor()
		{
			var link = "http://www.foo.com/bar?baz=qux#hash";

			var url = new Url(link);

			Assert.AreEqual(url.Protocol, "http:");
			Assert.AreEqual(url.Username, "");
			Assert.AreEqual(url.Password, "");
			Assert.AreEqual(url.Host, "www.foo.com");
			Assert.AreEqual(url.Hostname, "www.foo.com");
			Assert.AreEqual(url.Port, 0);
			Assert.AreEqual(url.Pathname, "/bar");
			Assert.AreEqual(url.Search, "?baz=qux");
			Assert.AreEqual(url.Hash, "#hash");
		}

		[Test]
		[Category("Url")]
		public void AllProperties_AreSet_WhenValidUrlAndBaseUrlPassedToCtor()
		{
			var link = "bar?baz=qux#hash";
			var baseUrl = "http://www.foo.com";

			var url = new Url(link, baseUrl);

			Assert.AreEqual(url.Protocol, "http:");
			Assert.AreEqual(url.Username, "");
			Assert.AreEqual(url.Password, "");
			Assert.AreEqual(url.Host, "www.foo.com");
			Assert.AreEqual(url.Hostname, "www.foo.com");
			Assert.AreEqual(url.Port, 0);
			Assert.AreEqual(url.Pathname, "/bar");
			Assert.AreEqual(url.Search, "?baz=qux");
			Assert.AreEqual(url.Hash, "#hash");
		}
	}
}
