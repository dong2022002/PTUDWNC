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
	public class DiscountMap : IEntityTypeConfiguration<Discount>
	{
		
		public void Configure(EntityTypeBuilder<Discount> builder)
		{
			builder.ToTable("Discounts");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Description)
				.HasMaxLength(1000);

			builder.Property(x => x.DiscountPercent)
				.HasDefaultValue(0);

			builder.Property(x => x.Active)
				.HasDefaultValue (false);

			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.DeletedAt)
				.HasColumnType("datetime");
		

		}
	}
}
