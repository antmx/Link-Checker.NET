using System;
using System.Net.Http;

namespace Netricity.Linkspector.Core
{
   public interface IContentParserFactory
   {
      IContentParser Create();

      void Release(IContentParser contentParser);
   }
}
