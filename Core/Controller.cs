using System;

namespace Netricity.LinkChecker.Core
{
	public class Controller : IController
	{
		public Controller(IResourceLog resourceLog, IContentParser contentParser, IDownloader downloader)
		{
			this.ResourceLog = resourceLog;
			this.ContentParser = contentParser;
			this.Downloader = downloader;
		}

		public void Start(string startUrl)
		{
			var url = new Url(startUrl);

			this.ResourceLog.AddItem(url);


		}

		public IUrl StartUrl { get; set; }
		
		public IResourceLog ResourceLog { get; set; }

		public IContentParser ContentParser { get; set; }

		public IDownloader Downloader { get; set; }

		public void ProcessNext()
		{
			throw new NotImplementedException();
		}

		public bool IsSuccessHttpStatus(string status)
		{
			throw new NotImplementedException();
		}

		public bool IsInternalUrl(IResource resource)
		{
			throw new NotImplementedException();
		}

		public int MaxProcesses
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public event EventHandler OnUpdate;
	}
}
