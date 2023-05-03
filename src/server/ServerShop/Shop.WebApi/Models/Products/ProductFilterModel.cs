namespace Shop.WebApi.Models.Products
{
	public class ProductFilterModel : PagingModel
	{
		public string Keyword { get; set; } = null;
		public string TitleSlug { get; set; } = null;
		public string CategorySlug { get; set; } = null;
		public int? CategoryId { get; set; }
	}
}
