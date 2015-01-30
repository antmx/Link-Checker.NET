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
			var url = new Url("http://www.foo.com/Page.html");

			log.AddItem(url);
			//log.AddItem("http://www.foo.com/Page.html");

			Assert.AreEqual(1, log.ItemCount);
		}

		//[Test]
		//[Category("ResourceLog")]
		//public void AddItem_Adds2ItemsThatOnlyDifferByCase_WhenCaseSensitive()
		//{
		//	var log = new ResourceLog(true);

		//	log.AddItem("http://www.foo.com/Page.html");
		//	log.AddItem("http://www.foo.com/Page.html");
		//}
	}
}
