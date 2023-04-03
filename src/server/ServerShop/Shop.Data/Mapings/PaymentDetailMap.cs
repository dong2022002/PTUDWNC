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
	public class PaymentDetailMap : IEntityTypeConfiguration<PaymentDetail>
	{
		
		public void Configure(EntityTypeBuilder<PaymentDetail> builder)
		{
			builder.ToTable("PaymentDetail");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Amount)
				.HasDefaultValue(0);

			builder.Property(x => x.Provider)
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(x => x.Status)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");

			builder.HasOne(x => x.OrderDetail)
				.WithOne(x => x.PaymentDetail)
				.HasForeignKey<PaymentDetail>(x => x.OrderId)
				.HasConstraintName("FK_PaymentDetail_OrderDetail")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
