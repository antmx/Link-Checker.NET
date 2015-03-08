using System;
using System.Linq;

namespace Netricity.LinkChecker.Core
{
	public class Resource : IResource
	{
		public Resource(IUrl2 url, bool caseSensitive)
		{
			this.Url = url;
			//this.LogStatus = "pending"; // "in progress" | "complete" | "not found" | "timeout"
			this.ResourceStatus = ResourceStatusEnum.Pending; // "in progress" | "complete" | "not found" | "timeout"
			this.CaseSensitive = caseSensitive;

			// Define properties that come from the XHR and its response headers.
			this.ContentType = "";
			this.ContentLength = 0;
			this.Server = "";
			this.CacheControl = "";
			this.Date = null;
			this.ContentEncoding = "";
			this.ContentLanguage = "";
			this.Status = "";
			this.LastModified = null;

			/* Properties that come from the resource's HTML */
			this.Title = url.Title ?? ""; // May also get overwritten after HTML is downloaded and parsed
			this.Description = "";

			/* Stats */
			this.PercentageComplete = 0;
			this.Level = 0;
			this.OutLinks = 0;
			this.InLinks = 0;
			this.Error = "";
			this.DateStart = null;
			this.DateEnd = null;
		}

		public IUrl2 Url { get; set; }

		//public string LogStatus { get; set; }
		public ResourceStatusEnum ResourceStatus { get; set; }

		public bool CaseSensitive { get; set; }

		public string ContentType { get; set; }

		public int ContentLength { get; set; }

		public string ContentEncoding { get; set; }

		public string ContentLanguage { get; set; }

		public string Server { get; set; }

		public string CacheControl { get; set; }

		public DateTime? Date { get; set; }

		public string Status { get; set; }

		public DateTime? LastModified { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int PercentageComplete { get; set; }

		public int Level { get; set; }

		public int OutLinks { get; set; }

		public int InLinks { get; set; }

		public string Error { get; set; }

		public DateTime? DateStart { get; set; }

		public DateTime? DateEnd { get; set; }

		public TimeSpan Duration
		{
			get { throw new NotImplementedException(); }
		}

		public void LoadXhr(object xhr)
		{
			throw new NotImplementedException();
		}

		public void LoadContentType(string contentType)
		{
			throw new NotImplementedException();
		}
	}
}
