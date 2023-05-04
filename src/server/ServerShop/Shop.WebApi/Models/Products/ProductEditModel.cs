using Microsoft.AspNetCore.Http;
using Shop.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Shop.WebApi.Models.Products
{
	public class ProductEditModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public IFormFile ImageFile { get; set; }
		public double Price { get; set; }

		public int ProductCategoryId { get; set; }
		public int Quantity { get; set; }
		public int DiscountId { get; set; }

		public static async ValueTask<ProductEditModel> BindAsync(
			HttpContext context)
		{
			var form = await context.Request.ReadFormAsync();
			return new ProductEditModel()
			{
				ImageFile = form.Files["ImageFile"],
				Id = int.Parse(form["Id"]),
				Quantity = int.Parse(form["Quantity"]),
				Price = double.Parse(form["Price"]),
				Name = form["Name"],
				Description = form["Description"],
				ProductCategoryId = int.Parse(form["ProductCategoryId"]),
				DiscountId = int.Parse(form["DiscountId"]),
			};
		}
	}
}
