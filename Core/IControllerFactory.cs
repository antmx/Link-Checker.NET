using System;
using System.Net.Http;

namespace Netricity.Linkspector.Core
{
   public interface IControllerFactory
   {
      IController Create(IResourceLog resourceLog, IContentParserFactory contentParserFactory, IDownloaderFactory downloaderFactory);

      void Release(IController downloader);
   }
}
