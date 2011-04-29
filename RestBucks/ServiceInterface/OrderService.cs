using System;

using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

using RestBucks.Resources;
using RestBucks.Responses;

namespace RestBucks.Services
{
	public class OrderService : RestServiceBase<Order>
	{
		public IDbConnectionFactory DbFactory { get; set; }

		public override object OnGet(Order request)
		{
			if (request.Id > 0)
			{
				return new GetOrderResponse { Order = DbFactory.Exec(dbCmd => dbCmd.GetById<Order>(request.Id)) };
			}
			else
			{
				return new ListOrderResponse { Orders = DbFactory.Exec(dbCmd => dbCmd.Select<Order>()) };
			}
		}

		public override object OnPut(Order order)
		{
			var orderId = DbFactory.Exec(dbCmd => 
					{
						dbCmd.Save(order);
						return dbCmd.GetLastInsertId();
					});

			return new PlaceOrderResponse { Order = DbFactory.Exec(dbCmd => dbCmd.GetById<Order>(orderId)) };
		}
	}
}
