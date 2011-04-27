using System;

using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

using RestBucks.Resources;
using RestBucks.Responses;

namespace RestBucks.Services
{
	public class OrderService : RestServiceBase<Order>
	{
		public override object OnGet(Order request)
		{
			var order = new Order { Id = 666 };
			return new PlaceOrderResponse { Order = order };
		}

		public override object OnPut(Order request)
		{
			var order = new Order { Id = 123 };
			return new PlaceOrderResponse { Order = order };
		}
	}
}
