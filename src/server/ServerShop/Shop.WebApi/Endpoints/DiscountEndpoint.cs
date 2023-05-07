using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Shop.Core.Collections;
using Shop.Core.dto;
using Shop.Core.Entities;
using Shop.Services.Shops;
using Shop.WebApi.Models.Category;
using Shop.WebApi.Models.Products;
using Shop.WebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using Shop.WebApi.Models.DiscountModel;
using Mapster;

namespace Shop.WebApi.Endpoints
{
	public static class DiscountEndpoint
	{
		public static WebApplication MapDiscountEndpoints(
		this WebApplication app)
		{
			var routerGroupBuilder = app.MapGroup("/api/discount");

			routerGroupBuilder.MapGet("/", GetPagedDiscount)
				.WithName("GetPagedDiscount")
				.Produces<ApiResponse<PaginationResult<DiscountDto>>>();

			routerGroupBuilder.MapPost(
				"/",
				AddOrUpdateDiscount)
				.Accepts<DiscountEditModel>("multipart/form-data")
				.WithName("AddDiscount")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<DiscountDto>>();

			routerGroupBuilder.MapPut(
				"/",
				AddOrUpdateDiscount)
				.Accepts<DiscountEditModel>("multipart/form-data")
				.WithName("UpdateDiscount")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<DiscountDto>>();

			routerGroupBuilder.MapDelete(
				"/{id:int}",
				DeleteDiscount)
				.WithName("DeleteDiscount")
				//.RequireAuthorization()
				.Produces(401)
				.Produces<ApiResponse<string>>();
			return app;
		}


		private static async Task<IResult> GetPagedDiscount(
		[AsParameters] DiscountFilterModel model,
		IDiscountRepository discountRepository,
		IMapper mapper
		)
		{
			var discountQuery = mapper.Map<DiscountQuery>(model);
			var discounts = await
				discountRepository.GetPagedDiscountAsync(
					model,
					discounts => discounts.ProjectToType<DiscountDto>(),
					discountQuery);

			var paginationResult =
				new PaginationResult<DiscountDto>(discounts);

			return Results.Ok(ApiResponse.Success(paginationResult));
		}

		private static async Task<IResult> AddOrUpdateDiscount(
			HttpContext context,
			IDiscountRepository discountRepository,
			IMapper mapper)
		{
			var model = await DiscountEditModel.BindAsync(context);
			var discount = model.Id > 0 ? await discountRepository.GetDiscountById(model.Id)
				: null;
			if (discount == null)
			{
				discount = new Discount()
				{
					CreatedAt = DateTime.Now
				};
			}

			discount.Name = model.Name;
			discount.Description = model.Description;
			discount.DiscountPercent = model.DiscountPercent;
			discount.Active = model.Active;
			if (model.Id > 0)
			{
				discount.ModifiedAt = DateTime.Now;
			}


			await discountRepository.AddOrUpdateDiscountsAsync(discount);

			return Results.Ok(ApiResponse.Success(
				"Request success", HttpStatusCode.NoContent));
		}


		private static async Task<IResult> DeleteDiscount(
			int id,
			IDiscountRepository discountRepository)
		{
			return await discountRepository.DeleteDiscountAsync(id)
				? Results.Ok(ApiResponse.Success("Discount is Deleted", HttpStatusCode.NoContent))
				: Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Could not find discount"));
		}
	}
}
