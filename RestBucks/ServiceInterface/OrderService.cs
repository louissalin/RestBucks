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
			if (request.Id > 1)
			{
				var order = new Order { Id = 666 };
				return new PlaceOrderResponse { Order = order };
			}
			else
			{
				return new ListOrderResponse { Orders = DbFactory.Exec(dbCmd => dbCmd.Select<Order>()) };
			}
		}

		public override object OnPut(Order request)
		{
			var order = new Order { Id = 123 };
			return new PlaceOrderResponse { Order = order };
		}
	}
}
