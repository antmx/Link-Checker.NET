using System;

namespace Netricity.Linkspector.Core
{
	public class Controller : IController
	{
		public Controller(IResourceLog resourceLog, IContentParser contentParser, IDownloaderFactory downloaderFactory)
		{
			this.ResourceLog = resourceLog;
			this.ContentParser = contentParser;
			this.DownloaderFactory = downloaderFactory;
		}

		public void Start(string startUrl, bool caseSensitive)
		{
			var url = new Uri2(startUrl);
			this.ResourceLog.CaseSensitive = caseSensitive;
			this.ResourceLog.AddItem(url);

         ProcessUrl(url);
		}

		public void ProcessNext()
		{
         //throw new NotImplementedException();
         if (this.CurrentProcesses < this.MaxProcesses)
         {
            var nextUrl = this.ResourceLog.FetchNextPendingUrl();

            if (nextUrl != null)
            {
               this.ProcessUrl(nextUrl);
               this.CurrentProcesses += 1;
            }
         }
      }

      public void ProcessUrl(IUrl url)
      {
         var resource = this.ResourceLog.FindItem(url);

         try
         {
            if (resource.Status == "pending")
            {
               //var downloader=this.DownloaderFactory.Create()
            }
         }
         catch (Exception e)
         {
            //resource.Status = xhr.status;
            //resource.LogStatus = xhr.statusText || "error";
         }
      }

		public Uri2 StartUrl { get; set; }

		public IResourceLog ResourceLog { get; set; }

		public IContentParser ContentParser { get; set; }

		public IDownloaderFactory DownloaderFactory { get; set; }

		public bool IsSuccessHttpStatus(string status)
		{
			throw new NotImplementedException();
		}

		public bool IsInternalUrl(IResource resource)
		{
			throw new NotImplementedException();
		}

		public int CurrentProcesses { get; set; }

      public int MaxProcesses { get; set; }

      public event EventHandler OnUpdate;
	}
}
