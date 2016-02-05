using System;
using System.Collections.Generic;
using System.Linq;

namespace Netricity.Linkspector.Core
{
	public interface IResourceLog
	{
		bool CaseSensitive { get; set; }

		ICollection<IResource> Items { get; set; }

		IResource AddItem(IUrl2 url);

		void AddItems(IEnumerable<IUrl2> urls);

		IUrl2 FetchNextPendingUrl();

		IResource FindItem(IUrl2 url);

		int ItemCount { get; }

		int PendingCount { get; }

		int CompletedCount { get; }
	}
}
