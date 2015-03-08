using System;
using Moq;
using Netricity.LinkChecker.Core;
using NUnit;
using NUnit.Framework;

namespace CoreTests
{
	[TestFixture]
	[Category("Uri2")]
	public class Uri2Tests
	{
		[Test]
		public void AllProperties_AreSet_WhenValidUrlPassedToCtor()
		{
			var link = "http://www.foo.com/bar?baz=qux#hash";

			var url = new Uri2(link);

			Assert.AreEqual("http", url.Scheme);
			Assert.AreEqual("", url.UserInfo);
			Assert.AreEqual("www.foo.com", url.Host);
			Assert.AreEqual("www.foo.com", url.Authority);
			Assert.AreEqual(80, url.Port);
			Assert.AreEqual("/bar?baz=qux", url.PathAndQuery);
			Assert.AreEqual("?baz=qux", url.Query);
			Assert.AreEqual("#hash", url.Fragment);
		}

		[Test]
		public void AllProperties_AreSet_WhenValidUrlAndBaseUrlPassedToCtor()
		{
			var relativeUri = "bar?baz=qux#hash";
			var baseUrl = new Uri2("http://www.foo.com");
			var url = new Uri2(baseUrl, relativeUri);

			Assert.AreEqual("http", url.Scheme);
			Assert.AreEqual("", url.UserInfo);
			Assert.AreEqual("www.foo.com", url.Host);
			Assert.AreEqual("www.foo.com", url.Authority);
			Assert.AreEqual(80, url.Port);
			Assert.AreEqual("/bar?baz=qux", url.PathAndQuery);
			Assert.AreEqual("?baz=qux", url.Query);
			Assert.AreEqual("#hash", url.Fragment);
		}
	}
}
