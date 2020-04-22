using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarbleAndEarth.Models
{
	public class Purchases
	{
		
		public int Id { get; set; }
		public string CustomerId { get; set; }
		public string ProductId { get; set; }
		public DateTime PurchaseDate { get; set; }
		public string ShippingAddr { get; set; }
		public string ShippingCity { get; set; }
		public string ShippingState { get; set; }
		public string PayMethod { get; set; }
	}
}