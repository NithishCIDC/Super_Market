using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Domain.Models
{
	public class ProductModel
	{
		[Display(Name = "Product ID")]
		public Guid id { get; set; }
		public required string Name { get; set; }
		public required int Quantity { get; set; }
		[Display(Name = "Price (Rs.)")]
		public required decimal Price { get; set; }
		[Display(Name = "Discount (%)")]
		public int? Discount { get; set; } = 0;
	}
}
