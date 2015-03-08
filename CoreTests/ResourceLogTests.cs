using System;
using Moq;
using Netricity.LinkChecker.Core;
using NUnit;
using NUnit.Framework;

namespace CoreTests
{
	[TestFixture]
	public class ResourceLogTests
	{
		[Test]
		[Category("ResourceLog")]
		public void ItemCount_EqualsZero_WhenNoItems()
		{
			var log = new ResourceLog(false);

			Assert.IsTrue(log.ItemCount == 0);
		}

		[Test]
		[Category("ResourceLog")]
		public void PendingCount_EqualsZero_WhenNoItems()
		{
			var log = new ResourceLog(false);

			Assert.IsTrue(log.PendingCount == 0);
		}

		[Test]
		[Category("ResourceLog")]
		public void AddItem_AddsTheItemToTheLog_WhenCalled()
		{
			var log = new ResourceLog(true);
			var url = new Uri2("http://www.foo.com/Page.html");

			log.AddItem(url);

			Assert.AreEqual(1, log.ItemCount);
		}

		[Test]
		[Category("ResourceLog")]
		public void AddItem_Adds2ItemsThatOnlyDifferByCase_WhenCaseSensitive()
		{
			var log = new ResourceLog(true);

			var urlA = new Uri2("http://www.foo.com/page.html");
			var urlB = new Uri2("http://www.foo.com/Page.html");

			log.AddItem(urlA);
			log.AddItem(urlB);

			Assert.AreEqual(2, log.ItemCount);
		}

		[Test]
		[Category("ResourceLog")]
		public void AddItem_Adds1ItemWhen2OnlyDifferByCase_WhenCaseInsensitive()
		{
			var log = new ResourceLog(false);

			var urlA = new Uri2("http://www.foo.com/page.html");
			var urlB = new Uri2("http://www.foo.com/Page.html");

			log.AddItem(urlA);
			log.AddItem(urlB);

			Assert.AreEqual(1, log.ItemCount);
		}
	}
}
