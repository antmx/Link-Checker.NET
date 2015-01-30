using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netricity.LinkChecker.Core
{
	public interface IResourceLog
	{
		bool CaseSensitive { get; set; }

		ICollection<IResource> Items { get; set; }

		IResource AddItem(IUrl url);

		void AddItems(IEnumerable<IUrl> urls);

		string FetchNextPendingUrl();

		IResource FindItem(IUrl url);

		int ItemCount { get; }

		int PendingCount { get; }

		int CompletedCount { get; }
	}
}
