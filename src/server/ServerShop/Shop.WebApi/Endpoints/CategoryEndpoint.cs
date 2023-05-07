using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Shop.Core.Collections;
using Shop.Core.DTO;
using Shop.Core.Entities;
using Shop.Services.Media;
using Shop.Services.Shops;
using Shop.WebApi.Models.Products;
using Shop.WebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using Mapster;
using Shop.WebApi.Models.Category;
using Shop.Core.dto;
using Microsoft.IdentityModel.Tokens;
using Shop.Services.Extensions;

namespace Shop.WebApi.Endpoints
{
	public static class CategoryEndpoint
	{
		public static WebApplication MapCategoriesEndpoints(
		this WebApplication app)
		{
			var routerGroupBuilder = app.MapGroup("/api/categories");

			routerGroupBuilder.MapGet("/", GetCategories)
				.WithName("GetCategories")
				.Produces<ApiResponse<IList<CategoryDto>>>();
			routerGroupBuilder.MapGet("/randomCategories/{limit:int}", GetRandomCategories)
				.WithName("GetRandomCategories")
				.Produces<ApiResponse<IList<CategoryDto>>>();

			routerGroupBuilder.MapGet("/PagedCategories", GetPagedCategories)
				.WithName("GetPagedCategories")
				.Produces<ApiResponse<PaginationResult<CategoryDto>>>();

			routerGroupBuilder.MapGet("/{slug}", GetCategoryDetails)
				.WithName("GetCategoryDetails")
				.Produces<ApiResponse<CategoryDto>>();

			routerGroupBuilder.MapPost(
				"/",
				AddOrUpdateCategory)
				.Accepts<CategoryEditModel>("multipart/form-data")
				.WithName("AddCategory")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<CategoryDto>>();

			routerGroupBuilder.MapPut(
				"/",
				AddOrUpdateCategory)
				.Accepts<ProductEditModel>("multipart/form-data")
				.WithName("UpdateCategory")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<CategoryDto>>();

			routerGroupBuilder.MapDelete(
				"/{id:int}",
				DeleteCategory)
				.WithName("DeleteCategory")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<string>>();
			return app;
		}



		private static async Task<IResult> GetCategories(
			ICategoryRepository categoryRepository,
			IMapper mapper)
		{
			var categories = await
				categoryRepository.GetAllCategoriesProduct(
					categories => categories.ProjectToType<CategoryDto>());

			return Results.Ok(ApiResponse.Success(categories));
		}

		private static async Task<IResult> GetRandomCategories(
			int limit,
			ICategoryRepository categoryRepository)
		{
			var categories = await categoryRepository
				.GetRandomCategories(limit, categories => categories.ProjectToType<CategoryDto>());
			return Results.Ok(ApiResponse.Success(categories));

		}

		private static async Task<IResult> GetPagedCategories(
		[AsParameters] CategoryFilterModel model,
		ICategoryRepository categoryRepository,
		IMapper mapper
		)
		{
			var categoryQuery = mapper.Map<CategoryQuery>(model);
			var categories = await
				categoryRepository.GetPagedCategoriesAsync(
					model,
					categories => categories.ProjectToType<CategoryDto>(),
					categoryQuery);

			var paginationResult =
				new PaginationResult<CategoryDto>(categories);

			return Results.Ok(ApiResponse.Success(paginationResult));
		}

		private static async Task<IResult> AddOrUpdateCategory(
			HttpContext context,
			ICategoryRepository categoryRepository,
			IMapper mapper)
		{
			var model = await CategoryEditModel.BindAsync(context);
			var slug = model.Name.GenerateSlug();

			if (await categoryRepository
				.IsCateogrySlugExistedAsync(model.Id, slug))
			{
				return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug đã được sử dụng"));
			}
			var category = model.Id > 0 ? await categoryRepository.GetcategoryById(model.Id)
				: null;
			if (category == null)
			{
				category = new ProductCategory()
				{
					CreatedAt = DateTime.Now
				};
			}

			category.Name = model.Name;
			category.Description = model.Description;
			if (model.Id > 0)
			{
				category.ModifiedAt = DateTime.Now;
			}
			category.Slug = model.Name.GenerateSlug();

			
			await categoryRepository.AddOrUpdateCategoryAsync(category);

			return Results.Ok(ApiResponse.Success(
				"Request success", HttpStatusCode.NoContent));
		}


		private static async Task<IResult> DeleteCategory(
			int id,
			ICategoryRepository categoryRepository)
		{
			return await categoryRepository.DeleteCategoryAsync(id)
				? Results.Ok(ApiResponse.Success("Category is Deleted", HttpStatusCode.NoContent))
				: Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Could not find category"));
		}
		private static async Task<IResult> GetCategoryDetails(
					string slug,
					IMapper mapper,
					ICategoryRepository categoryRepository)
		{
			var category = await categoryRepository
				.GetCategoryBySlug(slug);

			return category == null
				? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy danh mục"))
				: Results.Ok(ApiResponse.Success(mapper.Map<CategoryDto>(category)));
		}

	}
}
