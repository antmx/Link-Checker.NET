using System;
using System.Collections.Generic;
using System.Linq;

namespace Netricity.Linkspector.Core
{
	public class ResourceLog : IResourceLog
	{
		//public ResourceLog(bool caseSensitive)
		public ResourceLog()
		{
			this.Items = new List<IResource>();
			//this.CaseSensitive = caseSensitive;
		}

		public bool CaseSensitive { get; set; }

		public ICollection<IResource> Items { get; set; }

		public void AddItems(IEnumerable<IUrl2> urls)
		{
			throw new NotImplementedException();
		}

		public IResource AddItem(IUrl2 url)
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

      public IUrl2 FetchNextPendingUrl()
      {
         foreach (var entry in this.Items)
         {
            if (entry.Status == "pending")
               return entry.Url;
         }

         return null;
      }

		public IResource FindItem(IUrl2 url)
		{
			var existing = this.Items
				//.Where(r => r.Url.IsEqualTo(url, this.CaseSensitive))
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
			get
			{
				return Items.Count(r => r.ResourceStatus == ResourceStatusEnum.Pending);
			}
		}

		public int CompletedCount
		{
			get
			{
				return Items.Count(r => r.ResourceStatus == ResourceStatusEnum.Completed);
			}
		}
	}
}
