using System;

namespace Netricity.Linkspector.Core
{
	public interface IController
	{
		void Start(string url, bool caseSensitive);

		IResourceLog ResourceLog { get; set; }

		IContentParser ContentParser { get; set; }

		IDownloaderFactory DownloaderFactory { get; set; }

		void ProcessNext();

		bool IsSuccessHttpStatus(string status);

		bool IsInternalUrl(IResource resource);

		int MaxProcesses { get; set; }

		event EventHandler OnUpdate;
	}
}
