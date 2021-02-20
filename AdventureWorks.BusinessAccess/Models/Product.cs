using System;
using System.ComponentModel.DataAnnotations;
#nullable enable
namespace AdventureWorks.Business.Models
{
	
	public class Product
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string ProductNumber { get; set; }
		
		public string Color { get; set; }
		public decimal StandardCost { get; set; }
		public decimal ListPrice { get; set; }
	
		public string Size { get; set; }
		public DateTime SellStartDate { get; set; }

		public Product()
		{
			Name = string.Empty;
			ProductNumber = string.Empty;
			Color = string.Empty;
			Size = string.Empty;
			SellStartDate = DateTime.Now;
		}
	}
}
