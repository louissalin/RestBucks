using System.Collections.Generic;

namespace RestBucks.Resources {

	public class Order {

		public string Location { get; set; }
		public List<OrderItem> Items { get; set; }
		public decimal Cost { get; set; }
		public string Status { get; set; }
	}

	public class OrderItem {

		public string Name { get; set; }
		public int Quantity { get; set; }
		public string Milk { get; set; }
		public string Size { get; set; }
	}
}
