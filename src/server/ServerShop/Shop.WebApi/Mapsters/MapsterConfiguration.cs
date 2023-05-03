using Mapster;
using Shop.Core.DTO;
using Shop.Core.Entities;
using Shop.WebApi.Models.Category;
using Shop.WebApi.Models.Products;

namespace Shop.WebApi.Mapsters
{
	public class MapsterConfiguration : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{

			config.NewConfig<ProductFilterModel, ProductQuery>();
			config.NewConfig<Product, ProductsDto>();


			config.NewConfig<ProductCategory, ProductCategoryDto>();


		}
	}
}
