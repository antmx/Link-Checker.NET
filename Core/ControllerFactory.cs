using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netricity.Linkspector.Core
{
   public class ControllerFactory : IControllerFactory
   {
      public IController Create(IResourceLog resourceLog, IContentParserFactory contentParserFactory, IDownloaderFactory downloaderFactory)
      {
         throw new NotImplementedException();
      }

      public void Release(IController downloader)
      {
         throw new NotImplementedException();
      }
   }
}
