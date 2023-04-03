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
	public class OderDetailMap : IEntityTypeConfiguration<OrderDetail>
	{
		//public int Id { get; set; }
		//public double Total { get; set; }

		//public DateTime CreatedAt { get; set; }
		//public DateTime ModifiedAt { get; set; }
		//public int UserId { get; set; }
		//public int PaymentId { get; set; }

		//public PaymentDetail PaymentDetail { get; set; }
		//public User User { get; set; }

		//public OrderItem OrderItem { get; set; }
		public void Configure(EntityTypeBuilder<OrderDetail> builder)
		{
			builder.ToTable("OrderDetail");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Total)
				.HasDefaultValue(0);

			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");

			builder.HasOne(x => x.User)
				.WithOne(x => x.OrderDetail)
				.HasForeignKey<OrderDetail>(x => x.UserId)
				.HasConstraintName("FK_User_OrderDetail")
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.PaymentDetail)
				.WithOne(x => x.OrderDetail)
				.HasForeignKey<OrderDetail>(x => x.PaymentId)
				.HasConstraintName("FK_PaymentDetail_OrderDetail")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
