using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Netricity.LinkChecker.Core
{
	public class Downloader : IDownloader
	{
		public void Download()
		{
			throw new NotImplementedException();
		}

		public bool ProtocolSupport
		{
			get { throw new NotImplementedException(); }
		}

		public event EventHandler OnProgress;

		public event EventHandler OnLoad;

		public event EventHandler OnError;

		public event EventHandler OnTimeout;

		public event EventHandler OnLoadStart;

		public event EventHandler OnAbort;

		public event EventHandler OnLoadEnd;
	}
}
