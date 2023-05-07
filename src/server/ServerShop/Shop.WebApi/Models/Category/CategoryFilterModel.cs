namespace Shop.WebApi.Models.Category
{
	public class CategoryFilterModel : PagingModel
	{
		public string Keyword { get; set; } = null;

	}
}
