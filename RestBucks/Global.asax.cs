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
		public class HelloAppHost : AppHostBase
		{
			public HelloAppHost() : base("RestBucks Services", typeof(OrderService).Assembly) {}
			
			public override void Configure (Funq.Container container)
			{
				Routes
					.Add<Order>("/order");
			}
		}
		
		protected void Application_Start(object sender, EventArgs args)
		{
			new HelloAppHost().Init();
		}
	}
}

