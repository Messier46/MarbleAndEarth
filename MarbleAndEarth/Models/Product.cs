using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarbleAndEarth.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string Type { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public int Qty { get; set; }
	}
}