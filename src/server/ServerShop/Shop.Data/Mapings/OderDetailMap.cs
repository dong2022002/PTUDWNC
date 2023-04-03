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

		}
	}
}
