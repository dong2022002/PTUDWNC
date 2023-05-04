using Shop.Data.Contexts;
using Shop.Data.Seeders;

var context = new ShopDbContext();

var seeder = new DataSeeder(context);


seeder.Initialize();

var products = context.Products.ToList();

Console.WriteLine(products);