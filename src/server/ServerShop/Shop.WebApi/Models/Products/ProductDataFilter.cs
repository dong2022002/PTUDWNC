using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Shop.WebApi.Models.Products
{
	public class ProductDataFilter
	{
		public IEnumerable<SelectListItem> CategoryList { get; set; }

		public IEnumerable<SelectListItem> DiscountList { get; set; }
	}
}
