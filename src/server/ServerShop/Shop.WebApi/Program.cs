using Microsoft.AspNetCore.Builder;
using Shop.WebApi.Endpoints;
using Shop.WebApp.Extensions;
using Shop.WebApp.Mapsters;

var builder = WebApplication.CreateBuilder(args);
{
	builder
		.ConfigureCors()
		.ConfigureServices()
		.ConfigureMapster()
		.ConfigureSwaggerOpentApi();
}

var app = builder.Build();
{
	app.SetupRequestPipeline();
	app.UseDataSeeder();

	app.MapProductsEndpoints();
	app.MapCategoriesEndpoints();
	app.MapDiscountEndpoints();
	app.MapAdminEndpoints();

	app.Run();
}


