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
				.Produces<ApiResponse<IList<ProductCategoryDto>>>();

			return app;
		}



		private static async Task<IResult> GetCategories(
			ICategoryRepository categoryRepository,
			IMapper mapper
			)
		{
			var categories = await
				categoryRepository.GetAllCategoriesProduct(
					categories => categories.ProjectToType<ProductCategoryDto>());

			return Results.Ok(ApiResponse.Success(categories));
		}


	}
}
