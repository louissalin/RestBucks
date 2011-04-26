using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

using RestBucks.Resources;

namespace RestBucks
{
	public static class AppRoutes
	{
		public static void SetRoutes(IServiceRoutes Routes)
		{
			Routes
				.Add<Order>("/order", "GET")
				.Add<Order>("/order/{Id}", "GET")
				.Add<Order>("/order", "PUT");
		}
	}
}
