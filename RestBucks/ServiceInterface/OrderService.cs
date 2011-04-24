using ServiceStack.ServiceHost;

using RestBucks.Resources;
using RestBucks.Responses;

namespace RestBucks.Services
{
	public class OrderGetService : IRestGetService<Order>, IService<Order>
	{
		public object Get(Order request)
		{
			var order = new Order { Id = 666 };
			return new PlaceOrderResponse { Order = order };
		}

		public object Execute(Order request)
		{
			var order = new Order { Id = 456 };
			return new PlaceOrderResponse { Order = order };
		}
	}
}
