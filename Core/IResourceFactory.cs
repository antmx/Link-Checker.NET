using System;

namespace Netricity.Linkspector.Core
{
   public interface IResourceFactory
   {
      IResource Create();

      IResource Create(IUrl url, bool caseSensitive);

      void Release(IResource downloader);
   }
}
