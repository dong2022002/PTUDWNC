using Microsoft.AspNetCore.Http;
using Shop.WebApi.Models.Category;
using System.Threading.Tasks;

namespace Shop.WebApi.Models.DiscountModel
{
	public class DiscountEditModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double DiscountPercent { get; set; }
		public bool Active { get; set; } = false;

			public static async ValueTask<DiscountEditModel> BindAsync(
		HttpContext context)
		{
			var form = await context.Request.ReadFormAsync();
			return new DiscountEditModel()
			{
				Id = int.Parse(form["Id"]),
				Name = form["Name"],
				Description = form["Description"],
				DiscountPercent = double.Parse(form["DiscountPercent"]),
				Active = form["Active"] != "false",


			};
		}


	}
}
