using System;
using System.Net;
using NUnit.Framework;
using ServiceStack.Common.Web;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.ServiceClient.Web;
using ServiceStack.WebHost.Endpoints;

using RestBucks.Services;
using RestBucks.Resources;
using RestBucks.Responses;

namespace RestBucks.Tests {

	public class IntegrationTestBase 
		: AppHostHttpListenerBase {

		protected const string BaseUrl = "http://localhost:8080/";
		private static ILog log;

		public IntegrationTestBase()
			: base("RestBucks Examples", typeof(OrderService).Assembly)
		{
			LogManager.LogFactory = new DebugLogFactory();
			log = LogManager.GetLogger(GetType());
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

			Routes
				.Add<Order>("/order", "GET")
				.Add<Order>("/order/{Id}", "GET")
				.Add<Order>("/order", "PUT");
		}
	}


	[TestFixture]
	public class RestBucksServiceTests
		: IntegrationTestBase {

		private JsonServiceClient jsonClient;

		[TestFixtureSetUp]
		public void setup()
		{
			jsonClient = new JsonServiceClient("http://localhost:8080");
		}

		[Test]
		public void put_requests_work()
		{
			var response = jsonClient.Put<PlaceOrderResponse>("/order", new Order());
			Assert.AreEqual(response.Order.Id, 123);
		}

		[Test]
		public void get_requests_work()
		{
			var response = jsonClient.Get<PlaceOrderResponse>("/order");
			Assert.AreEqual(response.Order.Id, 666);
		}
	}
}
