using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Mapings
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		

		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Products");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Description)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.SKU)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Price)
				.HasDefaultValue(0);

			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.DeletedAt)
				.HasColumnType("datetime");

			builder.HasOne(x => x.ProductCategory)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.CategoryId)
				.HasConstraintName("FK_ProductCategory_Products")
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Discount)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.DiscountId)
				.HasConstraintName("FK_Discount_Products")
				.OnDelete(DeleteBehavior.Cascade);

		
		}
	}
}

