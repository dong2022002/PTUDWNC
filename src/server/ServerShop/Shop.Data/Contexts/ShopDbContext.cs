﻿using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TatBlog.Data.Contexts
{
	public class ShopDbContext : DbContext
	{
		public DbSet<AdminType> AdminTypes { get; set; }
		public DbSet<AdminUser> AdminUsers { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Discount> Discounts { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductInventory> ProductInventories { get; set; }
		public DbSet<ShoppingSession> ShoppingSessions { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserPayment> UserPayments { get; set; }

		//public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
		//{

		//}

		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=MSI;Database=ShopDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<PaymentDetail>()
				.HasOne(a => a.OrderDetail).WithOne(b => b.PaymentDetail)
				.HasForeignKey<OrderDetail>(e => e.PaymentId);
			modelBuilder.Entity<User>()
				.HasOne(a => a.OrderDetail).WithOne(b => b.User)
				.HasForeignKey<OrderDetail>(e => e.UserId);
			modelBuilder.Entity<ProductInventory>()
				.HasOne(a => a.Product).WithOne(b => b.ProductInventory)
				.HasForeignKey<Product>(e => e.InventoryId);
			

		}

	
	}
}