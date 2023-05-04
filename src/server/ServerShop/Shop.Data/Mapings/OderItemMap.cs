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
	public class OderItemMap : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable("OrderItems");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Quantity)
				.HasDefaultValue(0);

			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");

			builder.HasOne(x => x.OrderDetail)
				.WithMany(x => x.OrderItems)
				.HasForeignKey(x => x.OrderDetailId)
				.HasConstraintName("FK_OrderDetail_OrderItems")
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Product)
				.WithOne(x => x.OrderItem)
				.HasForeignKey<OrderItem>(x => x.ProductId)
				.HasConstraintName("FK_Product_OrderItems")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
