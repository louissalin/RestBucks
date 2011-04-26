using System;

using ServiceStack.ServiceHost;

using RestBucks.Resources;
using RestBucks.Responses;

namespace RestBucks.Services
{
	public class OrderService : IService<Order>,
			IRestGetService<Order>,
			IRestPutService<Order>
	{
		public object Get(Order request)
		{
			var order = new Order { Id = 666 };
			return new PlaceOrderResponse { Order = order };
		}

		public object Put(Order request)
		{
			var order = new Order { Id = 123 };
			return new PlaceOrderResponse { Order = order };
		}

		public object Execute(Order request)
		{
			throw new Exception("this should never get called");
		}
	}
}
