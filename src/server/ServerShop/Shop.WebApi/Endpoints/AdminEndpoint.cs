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
using Shop.WebApi.Models.AdminUserModel;

namespace Shop.WebApi.Endpoints
{
	public static class AdminEndpoint
	{
		public static WebApplication MapAdminEndpoints(
		this WebApplication app)
		{
			var routerGroupBuilder = app.MapGroup("/api/admin");

			routerGroupBuilder.MapPost(
				"/",
				CheckAdmin)
				.Accepts<AdminEditModel>("multipart/form-data")
				.WithName("CheckAdmin")
				.Produces(401)
				.Produces<ApiResponse<AdminUser>>();
			return app;
		}



	

		private static async Task<IResult> CheckAdmin(
			HttpContext context,
			IAdminUserRepository adminUserRepository,
			IMapper mapper)
		{
			var model = await AdminEditModel.BindAsync(context);

			var user =  await adminUserRepository.checkAdmin(model.UserName,model.Password);
			if (user != null)
			{
				return Results.Ok(ApiResponse.Success(
				user, HttpStatusCode.NoContent));
			}
			else
			{
				return Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "error"));
			}
			
		}


	
	}
}
