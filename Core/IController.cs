using System;

namespace Netricity.LinkChecker.Core
{
	public interface IController
	{
		void Start(string url, bool caseSensitive);

		IResourceLog ResourceLog { get; set; }

		IContentParser ContentParser { get; set; }

		IDownloader Downloader { get; set; }

		void ProcessNext();

		bool IsSuccessHttpStatus(string status);

		bool IsInternalUrl(IResource resource);

		int MaxProcesses { get; set; }

		event EventHandler OnUpdate;
	}
}
