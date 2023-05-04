using Shop.Core.Entities;
using Shop.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Seeders
{
	public class DataSeeder : IDataSeeder
	{
		private readonly ShopDbContext _context;
        public DataSeeder(ShopDbContext context)
        {
			_context = context;
        }
        public void Initialize()
		{
			_context.Database.EnsureCreated();
			if (_context.Products.Any()) return;
			var categories = AddCategories();
			var discounts = AddDiscounts();
			var products =  AddProducts(categories, discounts);
			var users = AddUsers();
		}

		private IList<User> AddUsers()
		{
			var users = new List<User>()
			{
				new()
				{
						UserName = "user123",
						Password = "user123",
						FirstName= "Dong",
						LastName = "Tran",
						CreatedAt = DateTime.Now,
						Address = null,
						PhoneNumber = null,
						ModifiedAt = null,
				},
				new()
				{
						UserName = "user4",
						Password = "user123",
						FirstName= "Dong 4",
						LastName = "Tran",
						CreatedAt = DateTime.Now,
						Address = null,
						PhoneNumber = null,
						ModifiedAt = null,
				},
				new()
				{
						UserName = "user5",
						Password = "user123",
						FirstName= "Dong 5",
						LastName = "Tran",
						CreatedAt = DateTime.Now,
						Address = null,
						PhoneNumber = null,
						ModifiedAt = null,
				},
			};
			_context.Users.AddRange(users);
			_context.SaveChanges();

			return users;
		}

		private IList<Product> AddProducts(IList<ProductCategory> categories, IList<Discount> discounts)
		{
			var products = new List<Product>()
			{
				new()
				{
					Name ="Laptop Dell 3558, i5-5200U, 2.4Ghz, RAM 4GB, SSD 128GB, 15.6” HD Win 10",
					Description ="Laptop Dell 3558, i5-5200U, 2.4Ghz, RAM 4GB, SSD 128GB, 15.6” HD Win 10",
					Slug = "laptop-dell-3558",
					ImageUrl = null,
					Price = 5850000,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
					viewCount= 0,
					ProductCategoryId = 2,
					Quantity = 10,
					DiscountId = 3,
				},
				new()
				{
					Name ="Laptop Dell Latitude E5450 Core I5 5300U Max 2.9 Ghz, Ram 4GB, SSD 120GB, chạy siêu nhanh, 14\", Máy đẹp như mới",
					Description ="Laptop Dell Latitude E5450 Core I5 5300U Max 2.9 Ghz, Ram 4GB, SSD 120GB, chạy siêu nhanh, 14\", Máy đẹp như mới",
					Slug = "laptop-dell-latitude-e5450",
					ImageUrl = null,
					Price = 6000000,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
					viewCount= 0,
					ProductCategoryId = 2,
					Quantity = 20,
					DiscountId = 2,
				},
				new()
				{
					Name ="HP ProBook 840 G1 Core i5 4300U max 2.9GHz, RAM 4GB, SSD 120GB ( Chạy siêu nhanh), 14″, đẹp như mới",
					Description ="HP ProBook 840 G1 Core i5 4300U max 2.9GHz, RAM 4GB, SSD 120GB ( Chạy siêu nhanh), 14″, đẹp như mới",
					Slug = "Hp-probook-840",
					ImageUrl = null,
					Price = 6200000,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
					viewCount= 0,
					ProductCategoryId = 2,
					Quantity = 20,
					DiscountId = 1,
				},
				new()
				{
					Name ="Laptop Asus VivoBook A515EP i5 1135G7/ 8GB/ 512GB/ 2GB MX330/ Win10",
					Description ="Laptop Asus VivoBook A515EP i5 1135G7/ 8GB/ 512GB/ 2GB MX330/ Win10",
					Slug = "laptop-asus-vivobook",
					ImageUrl = null,
					Price = 12000000,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
					viewCount= 0,
					ProductCategoryId = 2,
					Quantity = 10,
					DiscountId = 3,
				},
				new()
				{
					Name ="Máy bàn Core i3 2120 3.3Ghz, SSD 120GB, RAM 4GB, Main H61 VSP , Nguồn máy tính vision VSP ATX 750W",
					Description ="Máy bàn Core i3 2120 3.3Ghz, SSD 120GB, RAM 4GB, Main H61 VSP , Nguồn máy tính vision VSP ATX 750W",
					Slug = "may-ban-core-i3",
					ImageUrl = null,
					Price = 5000000,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
					viewCount= 0,
					ProductCategoryId = 1,
					Quantity = 5,
					DiscountId = 3,
				},
				new()
				{
					Name ="Máy bàn i5 2500 max 3.7Ghz , Mainboard VSP H61, RAM 4GB, SSD 120GB , Nguồn VSP 750W",
					Description ="Máy bàn i5 2500 max 3.7Ghz , Mainboard VSP H61, RAM 4GB, SSD 120GB , Nguồn VSP 750W",
					Slug = "may-ban-core-i5-2500",
					ImageUrl = null,
					Price = 6000000,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
					viewCount= 0,
					ProductCategoryId = 1,
					Quantity = 10,
					DiscountId = 2,
				},
				new()
				{
					Name ="Máy bàn i7 4790 tray, Max 4.0Ghz, Main ASUS H81 Chính hãng, Ram 8GB, nguồn CST 450w, SSD 240GB, case mặt kính KB08",
					Description ="Máy bàn i7 4790 tray, Max 4.0Ghz, Main ASUS H81 Chính hãng, Ram 8GB, nguồn CST 450w, SSD 240GB, case mặt kính KB08",
					Slug = "may-ban-i7-4790-tray",
					ImageUrl = null,
					Price = 4000000,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
					viewCount= 0,
					ProductCategoryId = 1,
					Quantity = 10,
					DiscountId = 1,
				},

			};
			_context.Products.AddRange(products);
			_context.SaveChanges();

			return products;
		}

		private IList<Discount> AddDiscounts()
		{
			var discount = new List<Discount>()
			{
				new()
				{
					Name = "discounts 50%",
					Description ="discounts 50%",
					DiscountPercent = 0.5,
					Active = true,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},
				new()
				{
					Name = "discounts 25%",
					Description ="discounts 25%",
					DiscountPercent = 0.25,
					Active = true,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},
				new()
				{
					Name = "discounts 10%",
					Description ="discounts 10%",
					DiscountPercent = 0.1,
					Active = true,
					CreatedAt= DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},

			};
			_context.Discounts.AddRange(discount);
			_context.SaveChanges();

			return discount;
		}

		
		private IList<ProductCategory> AddCategories()
		{
			var productCategory = new List<ProductCategory>()
			{
				new()
				{
					Name = "Máy tính bàn",
					Description = "Máy tính bàn",
					Slug = "may-tinh-ban",
					CreatedAt = DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},
				new()
				{
					Name = "Laptop",
					Description = "Laptop",
					Slug = "lab-top",
					CreatedAt = DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},
				new()
				{
					Name = "Linh kiện PC",
					Description = "Linh kiện PC",
					Slug = "linh-kien-pc",
					CreatedAt = DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},
				new()
				{
					Name = "Linh kiện Laptop",
					Description = "Linh kiện Laptop",
					Slug = "linh-kien-laptop",
					CreatedAt = DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},
				new()
				{
					Name = "SSD, HDD",
					Description = "SSD, HDD",
					Slug = "ssd-hdd",
					CreatedAt = DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},
				new()
				{
					Name = "Camera An Ninh",
					Description = "Camera An Ninh",
					Slug = "camera-an-ninh",
					CreatedAt = DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},
				new()
				{
					Name = "Bàn, Ghế Gaming",
					Description = "Bàn, Ghế Gaming",
					Slug = "ban-ghe-gaming",
					CreatedAt = DateTime.Now,
					ModifiedAt = null,
					DeletedAt = null,
				},

			};
			_context.ProductCategories.AddRange(productCategory);
			_context.SaveChanges();

			return productCategory;
		}
	}
}
