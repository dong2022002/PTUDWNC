using Microsoft.AspNetCore.Builder;
using Shop.WebApi.Endpoints;
using Shop.WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
	builder
		.ConfigureCors()
		.ConfigureServices()
		.ConfigureSwaggerOpentApi();
}

var app = builder.Build();
{
	app.SetupRequestPipeline();
	app.UseDataSeeder();

	app.MapProductsEndpoints();
	app.Run();
}


