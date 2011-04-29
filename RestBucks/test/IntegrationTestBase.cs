using System;
using System.Collections.Generic;

using Funq;
using ServiceStack.Common.Utils;
using ServiceStack.Common.Web;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.ServiceClient.Web;
using ServiceStack.WebHost.Endpoints;

using RestBucks.Services;
using RestBucks.Resources;

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

		public override void Configure (Container container)
		{
			container.Register<IResourceManager>(new ConfigurationResourceManager());
			container.Register<IDbConnectionFactory>(c =>
				new OrmLiteConnectionFactory(
					":memory:",
					false,
					SqliteOrmLiteDialectProvider.Instance));

			Init(container.Resolve<IDbConnectionFactory>());
			AppRoutes.SetRoutes(Routes);
		}

		private void Init(IDbConnectionFactory connectionFactory)
		{
			var orders = new List<Order> 
			{
				new Order
				{
					Id = 1,
					Location = "coffee shop",
					Item = new OrderItem 
						{
							Name = "Latte",
							Quantity = 1,
							Milk = "whole",
							Size = "Large"
						},
					Cost = 3.95m,
					Status = "Paid"
				},
				new Order
				{
					Id = 2,
					Location = "drive through window",
					Item = new OrderItem 
						{
							Name = "Drip coffee",
							Quantity = 3,
							Milk = "no milk",
							Size = "small"
						},
					Cost = 6.05m,
					Status = "In Process"
				},
				new Order
				{
					Id = 3,
					Location = "coffee shop",
					Item = new OrderItem 
						{
							Name = "Latte",
							Quantity = 1,
							Milk = "whole",
							Size = "Large"
						},
					Cost = 3.95m,
					Status = "ordered"
				},
			};

			try
			{
				using (var dbConn = connectionFactory.OpenDbConnection())
				using (var dbCmd = dbConn.CreateCommand())
				{
					dbCmd.CreateTable<Order>(false);
					dbCmd.SaveAll(orders);
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
