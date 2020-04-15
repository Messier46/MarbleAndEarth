using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarbleAndEarth.Models
{
	public class Purchases
	{
		
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int ProductId { get; set; }
		public DateTime PurchaseDate { get; set; }
	}
}