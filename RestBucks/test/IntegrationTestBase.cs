using System;
using ServiceStack.Common.Web;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.ServiceClient.Web;
using ServiceStack.WebHost.Endpoints;

using RestBucks.Services;

namespace RestBucks.Tests {

	public class IntegrationTestBase 
		: AppHostHttpListenerBase {

		protected const string BaseUrl = "http://localhost:8080/";

		public IntegrationTestBase()
			: base("RestBucks Examples", typeof(OrderService).Assembly)
		{
			LogManager.LogFactory = new DebugLogFactory();
			Instance = null;

			Init();
			try
			{
				Start(BaseUrl);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error trying to run ConsoleHost: " + ex.Message);
			}
		}

		public override void Configure (Funq.Container container)
		{
			container.Register<IResourceManager>(new ConfigurationResourceManager());
			AppRoutes.SetRoutes(Routes);
		}
	}
}
