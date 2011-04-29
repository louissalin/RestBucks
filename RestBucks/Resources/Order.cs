using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace RestBucks.Resources {

	public class Order {

		[AutoIncrement]
		public int Id { get; set; }
		public string Location { get; set; }
		public OrderItem Item { get; set; }
		public decimal Cost { get; set; }
		public string Status { get; set; }

		public List<Link> Links { get; set; }
	}

	public class OrderItem {

		public string Name { get; set; }
		public int Quantity { get; set; }
		public string Milk { get; set; }
		public string Size { get; set; }
	}
}
