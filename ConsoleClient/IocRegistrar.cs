using System;
using Castle;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Netricity.LinkChecker.Core;

namespace Netricity.LinkChecker.ConsoleClient
{
	public class IocRegistrar
	{
		private WindsorContainer _container;

		public void RegisterComponents()
		{
			// 1. Instantiate the IWindsor container object
			this._container = new WindsorContainer();

			// 2. Register the services and the respective components that implement them
			this._container.Register(
				Component.For<IController>().ImplementedBy<Controller>(),
				Component.For<IDownloader>().ImplementedBy<Downloader>(),
				Component.For<IContentParser>().ImplementedBy<ContentParser>(),
				Component.For<IResourceLog>().ImplementedBy<ResourceLog>()
			);
		}

		public IController ResolveController()
		{
			var controller = this._container.Resolve<IController>();

			return controller;
		}
	}
}
