using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

using RestBucks.Services;

namespace RestBucks
{
	public class RestBucksHost : AppHostBase
	{
		public RestBucksHost() : base("RestBucks Services", typeof(OrderService).Assembly) {}
		
		public override void Configure (Funq.Container container)
		{
			AppRoutes.SetRoutes(Routes);
		}
	}
	
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs args)
		{
			new RestBucksHost().Init();
		}
	}
}
