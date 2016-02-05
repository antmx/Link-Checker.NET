using System;
using System.Net.Http;

namespace Netricity.Linkspector.Core
{
   public interface IControllerFactory
   {
      IDownloader Create();

      IController Create(IResourceLog resourceLog, IContentParser contentParser, IDownloaderFactory downloaderFactory);

      void Release(IController downloader);
   }
}
