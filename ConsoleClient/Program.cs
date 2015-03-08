using System;
using Netricity.LinkChecker.Core;

namespace Netricity.LinkChecker.ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			// 3. "Resolve" the root service
			var controller = Init();

			controller.Start("http://www.breaks-in-summerland-tenerife.co.uk", false);
		}

		private static IController Init()
		{
			var ioc = new IocRegistrar();
			ioc.RegisterComponents();
			var controller = ioc.ResolveController();
			return controller;
		}
	}
}
