using ServiceStack.ServiceHost;
using RestBucks.Resources;
using RestBucks.Responses;

namespace RestBucks.Services
{
	public class HelloService : IService<Hello>
	{
		public object Execute(Hello request)
		{
			return new HelloResponse { Result = "Hello " + request.Name };
		}
	}
}
