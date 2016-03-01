using System;
using Netricity.Linkspector.Core;

namespace Netricity.Linkspector.ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
         var container = IocManager.Init();

         // 3. "Resolve" the root services
         var resourceLog = container.Resolve<IResourceLog>();
         //var contentParser = container.Resolve<IContentParser>();
         var contentParserFactory = container.Resolve<IContentParserFactory>();
         var httpMessageHandler = container.Resolve<IHttpMessageHandler>();
         var downloaderFactory = container.Resolve<IDownloaderFactory>();
         //var downloader = downloaderFactory.Create(httpMessageHandler);
         var controllerFactory = container.Resolve<IControllerFactory>();
         var controller = controllerFactory.Create(resourceLog, contentParserFactory, downloaderFactory);

         // Start
         controller.Start("http://www.breaks-in-summerland-tenerife.co.uk", false);
		}
	}
}
