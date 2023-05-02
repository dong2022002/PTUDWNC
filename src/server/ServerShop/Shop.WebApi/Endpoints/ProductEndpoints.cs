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
				.Produces<ApiResponse<IList<Product>>>();


			return app;
		}

		private static async Task<IResult> GetProducts(
			IProductRepository productRepository
			)
		{

			var products = await
				productRepository.GetAllProducts();

			return Results.Ok(ApiResponse.Success(products));
		}

	}
}
