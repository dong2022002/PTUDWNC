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
	public class CarItemMap : IEntityTypeConfiguration<CartItem>
	{
		
		public void Configure(EntityTypeBuilder<CartItem> builder)
		{
			builder.ToTable("CartItem");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Quantity)
				.IsRequired()
				.HasDefaultValue(0);
			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");

			builder.HasOne(x => x.ShoppingSession)
				.WithMany(x => x.Carts)
				.HasForeignKey(x => x.SessionId)
				.HasConstraintName("FK_CartItem_Sessions")
				.OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(x => x.Product)
				.WithOne(x => x.CartItem)
				.HasForeignKey<CartItem>(x => x.ProductId)
				.HasConstraintName("FK_Product_Sessions")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
