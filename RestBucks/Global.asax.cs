using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

using RestBucks.Services;
using RestBucks.Responses;
using RestBucks.Resources;

namespace RestBucks
{
	public class Global : System.Web.HttpApplication
	{
		public class RestBucksHost : AppHostBase
		{
			public RestBucksHost() : base("RestBucks Services", typeof(OrderGetService).Assembly) {}
			
			public override void Configure (Funq.Container container)
			{
				Routes
					.Add<Order>("/order", "GET")
					.Add<Order>("/order/{Id}", "GET")
					.Add<Order>("/order", "PUT");
			}
		}
		
		protected void Application_Start(object sender, EventArgs args)
		{
			new RestBucksHost().Init();
		}
	}
}

