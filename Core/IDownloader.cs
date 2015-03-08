﻿using System;
using System.Net.Http;

namespace Netricity.LinkChecker.Core
{
	public interface IDownloader
	{
		void Download(); // use async modifier on implementation

		bool IsSuccessHttpStatus(string httpStatus);

		bool IsProtocolSupported { get; }

		//event EventHandler OnProgress;

		//event EventHandler OnLoad;

		//event EventHandler OnError;

		//event EventHandler OnTimeout;

		//event EventHandler OnLoadStart;

		//event EventHandler OnAbort;

		//event EventHandler OnLoadEnd;

		Action<IResource> OnStart { get; set; }

		Action<IResource> OnComplete { get; set; }

		Action<IResource> OnError { get; set; }

		Action<IResource> OnTimeout { get; set; }
	}
}
