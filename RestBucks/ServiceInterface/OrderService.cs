using ServiceStack.ServiceHost;
using RestBucks.Resources;
using RestBucks.Responses;

namespace RestBucks.Services
{
	public class OrderService : IService<Order>
	{
		public object Execute(Order request)
		{
			var order = new Order();
			return new PlaceOrderResponse { Order = order };
		}
	}
}
