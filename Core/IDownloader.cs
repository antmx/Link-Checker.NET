using System;
using System.Net.Http;

namespace Netricity.LinkChecker.Core
{
	public interface IDownloader
	{
		void Download(); // use async modifier on implementation

		bool ProtocolSupport { get; }

		event EventHandler OnProgress;

		event EventHandler OnLoad;

		event EventHandler OnError;

		event EventHandler OnTimeout;

		event EventHandler OnLoadStart;

		event EventHandler OnAbort;

		event EventHandler OnLoadEnd;
	}
}
