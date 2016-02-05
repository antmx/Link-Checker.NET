using System;

namespace Netricity.Linkspector.Core
{
   public interface IResourceFactory
   {
      IResource Create();

      IResource Create(IUrl2 url, bool caseSensitive);

      void Release(IResource downloader);
   }
}
