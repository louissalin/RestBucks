using System;
using System.Net;
using NUnit.Framework;
using ServiceStack.Common.Web;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.ServiceClient.Web;
using ServiceStack.WebHost.Endpoints;

using RestBucks.Services;
using RestBucks.Resources;
using RestBucks.Responses;

namespace RestBucks.Tests {

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
		public void get_without_an_id_should_display_all_orders()
		{
			var response = jsonClient.Get<ListOrderResponse>("/order");
			Assert.AreEqual(response.Orders.Count, 3);
		}

		[Test]
		public void get_with_an_id_should_the_proper_order()
		{
			var response = jsonClient.Get<GetOrderResponse>("/order/2");
			Assert.AreEqual(response.Order.Id, 2);
		}
	}
}
