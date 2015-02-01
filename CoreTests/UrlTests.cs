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

			Assert.AreEqual(url.Hash, "hash");
		}
	}
}
