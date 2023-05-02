using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net;
using System.Net.Mail;
using Shop.Data.Seeders;
using Shop.Services.Media;
using Shop.Services.Timing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Contexts;
using Microsoft.Extensions.Configuration;
using Shop.Services.Shops;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Shop.WebApp.Extensions
{
	public static class WebApplicationExtensions
	{

		public static WebApplicationBuilder ConfigureCors(
			this WebApplicationBuilder builder)
		{
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("ShopApp", policyBuilder =>
						policyBuilder
						   .AllowAnyOrigin()
						   .AllowAnyHeader()
						   .AllowAnyMethod());
			
			});
	

			return builder;
		}

		public static WebApplicationBuilder ConfigureServices(
			this WebApplicationBuilder builder)
		{
			builder.Services.AddMemoryCache();

			builder.Services.AddDbContext<ShopDbContext>(options =>
					options.UseSqlServer(
								builder.Configuration
									.GetConnectionString("DefaultConnection")));
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IMediaManager, LocalFileSystemMediaManager>();
			builder.Services.AddScoped<ITimeProvider, LocalTimeProvider>();
			return builder;

		}

		public static WebApplication SetupRequestPipeline(
			this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseCors("ShopApp");
			return app;
		}
		public static WebApplicationBuilder ConfigureSwaggerOpentApi(
					this WebApplicationBuilder builder)
		{
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			return builder;
		}
		public static IApplicationBuilder UseDataSeeder(
			this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				try
				{
					scope.ServiceProvider
						.GetRequiredService<IDataSeeder>()
						.Initialize();
				}
				catch (Exception ex)
				{
					scope.ServiceProvider
						.GetRequiredService<ILogger<Program>>()
						.LogError(ex, "Could not insert data into database");
				}

			}
			return app;
		}
	}
}
