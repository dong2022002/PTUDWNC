using Shop.Core.Entities;
using System;

namespace Shop.WebApi.Models.Products
{
	public class ProductsDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public double Price { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public DateTime? DeletedAt { get; set; }

		public int ProductCategoryId { get; set; }
		public int Quantity { get; set; }
		public int DiscountId { get; set; }

		public CartItem CartItem { get; set; }
		public Discount Discount { get; set; }
		public ProductCategory ProductCategory { get; set; }
		public OrderItem OrderItem { get; set; }
	}
}
