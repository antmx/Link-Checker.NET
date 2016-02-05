using System;
using System.Net.Http;

namespace Netricity.Linkspector.Core
{
   public interface IDownloaderFactory
   {
      IDownloader Create();

      //IDownloader Create(HttpMessageHandler httpMessageHandler, IResource resource);
      IDownloader Create(IHttpMessageHandler httpMessageHandler);

      void Release(IDownloader downloader);
   }
}
