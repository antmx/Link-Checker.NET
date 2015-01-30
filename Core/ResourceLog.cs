using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netricity.LinkChecker.Core
{
	public class ResourceLog : IResourceLog
	{
		public ResourceLog(bool caseSensitive)
		{
			this.Items = new List<IResource>();
			this.CaseSensitive = caseSensitive;
		}

		public bool CaseSensitive { get; set; }

		public ICollection<IResource> Items { get; set; }

		public void AddItems(IEnumerable<IUrl> urls)
		{
			throw new NotImplementedException();
		}

		public IResource AddItem(IUrl url)
		{
			if (url == null)
				throw new ArgumentNullException("url");

			var matchingItem = FindItem(url);

			if (matchingItem != null)
			{
				// Update existing item's InLink count
				matchingItem.InLinks += 1;
				return matchingItem;
			}
			else
			{
				// Add new item
				var newItem = new Resource(url, this.CaseSensitive);
				newItem.InLinks = this.ItemCount == 0 ? 0 : 1;
				this.Items.Add(newItem);

				return newItem;
			}
		}

		public string FetchNextPendingUrl()
		{
			throw new NotImplementedException();
		}

		public IResource FindItem(IUrl url)
		{
			var existing = this.Items
				.Where(r => r.Url.IsEqualTo(url, this.CaseSensitive))
				.FirstOrDefault();

			return existing;
		}

		public int ItemCount
		{
			get { return this.Items.Count; }
		}

		public int PendingCount
		{
			get { throw new NotImplementedException(); }
		}

		public int CompletedCount
		{
			get { throw new NotImplementedException(); }
		}
	}
}
