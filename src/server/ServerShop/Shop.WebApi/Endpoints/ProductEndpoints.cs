using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Shop.Core.Collections;
using Shop.Services.Media;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using Shop.WebApi.Models.Products;
using Shop.Services.Shops;
using Shop.Core.Entities;
using Shop.WebApi.Models;
using Shop.Core.DTO;
using Mapster;
using Shop.Services.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.WebApi.Endpoints
{
	public static class ProductEndpoints
	{
		public static WebApplication MapProductsEndpoints(
		this WebApplication app)
		{
			var routerGroupBuilder = app.MapGroup("/api/products");

			routerGroupBuilder.MapGet("/", GetProducts)
				.WithName("GetProducts")
				.Produces<ApiResponse<PaginationResult<ProductsDto>>>();

			routerGroupBuilder.MapGet("/featured/{limit:int}", GetFeaturedProducts)
				.WithName("GetFeaturedProducts")
				.Produces<ApiResponse<IList<ProductsDto>>>();
			routerGroupBuilder.MapGet("/newestProduct/{limit:int}", GetNewProducts)
				.WithName("GetNewProducts")
				.Produces<ApiResponse<IList<ProductsDto>>>();
			routerGroupBuilder.MapGet("/discountProduct/{limit:int}", GetDiscountProducts)
				.WithName("GetDiscountProducts")
				.Produces<ApiResponse<IList<ProductsDto>>>();
			routerGroupBuilder.MapGet("/randomProduct/{limit:int}", GetRandomProducts)
				.WithName("GetRandomProducts")
				.Produces<ApiResponse<IList<ProductsDto>>>();

			routerGroupBuilder.MapGet("/{id:int}", GetProductDetails)
				.WithName("GetProductDetails")
				.Produces<ApiResponse<ProductsDto>>();

			routerGroupBuilder.MapGet("get-filter", GetFilter)
				.WithName("GetFilter")
				.Produces<ApiResponse<ProductDataFilter>>();


			routerGroupBuilder.MapPost(
				"/",
				AddProduct)
				.Accepts<ProductEditModel>("multipart/form-data")
				.WithName("AddNewProduct")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<ProductsDto>>();

			routerGroupBuilder.MapPut(
				"/",
				AddProduct)
				.Accepts<ProductEditModel>("multipart/form-data")
				.WithName("UpdateProduct")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<ProductsDto>>();

			routerGroupBuilder.MapDelete(
				"/{id:int}",
				DeleteProduct)
				.WithName("DeleteProduct")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<string>>();

			return app;
		}

		private static async Task<IResult> GetFeaturedProducts(
			int limit,
			IProductRepository productRepository)
		{
			var products = await productRepository
				.GetProductFeatured(limit, posts => posts.ProjectToType<ProductsDto>());
			return Results.Ok(ApiResponse.Success(products));

		}

		private static async Task<IResult> GetProductDetails(
			int id,
			IMapper mapper,
			IProductRepository productRepository)
		{
			var product = await productRepository
				.GetProductById(id);
		
			return product == null
				? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy sản phẩm có mã số {id}"))
				: Results.Ok(ApiResponse.Success(mapper.Map<ProductsDto>(product)));
		}


		private static async Task<IResult> GetNewProducts(
			int limit,
			IProductRepository productRepository)
		{
			var products = await productRepository
				.GetNewProduct(limit, posts => posts.ProjectToType<ProductsDto>());
			return Results.Ok(ApiResponse.Success(products));

		}

		private static async Task<IResult> GetDiscountProducts(
			int limit,
			IProductRepository productRepository)
		{
			var products = await productRepository
				.GetDiscountProduct(limit, posts => posts.ProjectToType<ProductsDto>());
			return Results.Ok(ApiResponse.Success(products));

		}

		private static async Task<IResult> GetRandomProducts(
		int limit,
		IProductRepository productRepository)
		{
			var products = await productRepository
				.getProductRandom(limit, posts => posts.ProjectToType<ProductsDto>());
			return Results.Ok(ApiResponse.Success(products));

		}

		private static async Task<IResult> GetProducts(
			[AsParameters] ProductFilterModel model,
			IProductRepository productRepository,
			IMapper mapper
			)
		{
			var productQuery = mapper.Map<ProductQuery>(model);
			var products = await
				productRepository.GetPagedProductAsync(
					model,
					products => products.ProjectToType<ProductsDto>(),
					productQuery);

			var paginationResult =
				new PaginationResult<ProductsDto>(products);

			return Results.Ok(ApiResponse.Success(paginationResult));
		}

		private static async Task<IResult> GetFilter(
		ICategoryRepository categoryRepository,
		IDiscountRepository discountRepository)
		{
			ProductDataFilter productDataFilter = new ProductDataFilter();
			var categories = await categoryRepository.GetCategoriesAsync();
			var discounts = await discountRepository.GetDiscountsAsync();
			productDataFilter.CategoryList = categories.Select(a => new SelectListItem()
			{
				Text = a.Name,
				Value = a.Id.ToString()
			});
			productDataFilter.DiscountList = discounts.Select(a => new SelectListItem()
			{
				Text = a.Name,
				Value = a.Id.ToString()
			});
			return Results.Ok(ApiResponse.Success(productDataFilter));
		}


		private static async Task<IResult> AddProduct(
			HttpContext context,
			IMediaManager mediaManager,
			IProductRepository productRepository,
			IMapper mapper)
		{
			var model = await ProductEditModel.BindAsync(context);
			var slug = model.Name.GenerateSlug();

			if (await productRepository
				.IsProductSlugExistedAsync(model.Id, slug))
			{
				return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug đã được sử dụng"));
			}

			//if (category == null || author == null)
			//{
			//	return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, "Nhập sai Id Chủ đề hoặc Tác giả"));

			//}
			var product = model.Id > 0 ? await productRepository.GetProductById(model.Id)
				: null;
			if (product == null)
			{
				product = new Product()
				{
					CreatedAt = DateTime.Now
				};
			}

			product.Name = model.Name;
			product.ProductCategoryId = model.ProductCategoryId;
			product.DiscountId = model.DiscountId;
			product.Price = model.Price;
			product.Quantity = model.Quantity;
			product.Slug = model.Name.GenerateSlug();
			product.Description = model.Description;
			if (model.Id > 0)
			{
				product.ModifiedAt = DateTime.Now;
			}
			product.Slug = model.Name.GenerateSlug();

			if (model.ImageFile?.Length > 0)
			{
               
                string hostname =
					$"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}/";
				if (!product.ImageUrl.IsNullOrEmpty())
				{
					string url = product.ImageUrl.Remove(0, hostname.Length);
					await mediaManager.DeleteFileAsync(url);
				}
				string uploadedPath = await mediaManager.SaveFileAsync(model.ImageFile.OpenReadStream(),
					model.ImageFile.FileName,
					model.ImageFile.ContentType);
				if (!string.IsNullOrWhiteSpace(uploadedPath))
				{
					product.ImageUrl = hostname + uploadedPath;
				}
			}
			await productRepository.AddOrUpdateProductsAsync(product);

			return Results.Ok(ApiResponse.Success(
				"Request success", HttpStatusCode.NoContent));
		}
		private static async Task<IResult> DeleteProduct(
			int id,
			IProductRepository blogRepository)
		{
			return await blogRepository.DeleteProductAsync(id)
				? Results.Ok(ApiResponse.Success("Product is Deleted", HttpStatusCode.NoContent))
				: Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Could not find product"));
		}
	}
}
