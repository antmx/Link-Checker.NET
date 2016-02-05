using System;

namespace Netricity.Linkspector.Core
{
	public interface IResource
	{
		#region Properties that come from the XHR and its response headers

		IUrl2 Url { get; set; }

		//string LogStatus { get; set; }
		ResourceStatusEnum ResourceStatus { get; set; }

		bool CaseSensitive { get; set; }

      string Content { get; set; }

		string ContentType { get; set; }

		long ContentLength { get; set; }

		string ContentEncoding { get; set; }

		string ContentLanguage { get; set; }

		string Server { get; set; }

		string CacheControl { get; set; }

		DateTime? Date { get; set; }

		string Status { get; set; }

		DateTime? LastModified { get; set; }

		#endregion

		#region Properties that come from resource HTML

		string Title { get; set; }

		string Description { get; set; }

		#endregion

		#region Stats

		int PercentageComplete { get; set; }

		int Level { get; set; }

		int OutLinks { get; set; }

		int InLinks { get; set; }

		string Error { get; set; }

		DateTime? DateStart { get; set; }

		DateTime? DateEnd { get; set; }

		#endregion

		TimeSpan Duration { get; }

		void LoadXhr(object xhr);

		void LoadContentType(string contentType);
	}
}
