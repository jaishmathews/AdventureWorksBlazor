using System;
using System.ComponentModel.DataAnnotations;
#nullable enable
namespace AdventureWorks.ViewModel
{
	
	public class ProductViewModel
	{
		public int ProductId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string ProductNumber { get; set; }
		
		public string Color { get; set; }
		[Required]
		[Range(1, 100)]
		public decimal StandardCost { get; set; }
		[Required]
		[Range(1,100)]
		public decimal ListPrice { get; set; }
	
		public string Size { get; set; }
		[Required]
		public DateTime SellStartDate { get; set; }

		public ProductViewModel()
		{
			Name = string.Empty;
			ProductNumber = string.Empty;
			Color = string.Empty;
			Size = string.Empty;
			SellStartDate = DateTime.Now;
		}
	}
}
