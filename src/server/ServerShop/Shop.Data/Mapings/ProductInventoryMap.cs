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
	public class ProductInventoryMap : IEntityTypeConfiguration<ProductInventory>
	{
		public void Configure(EntityTypeBuilder<ProductInventory> builder)
		{
			builder.ToTable("ProductInventory");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Quantity)
				.HasDefaultValue(0);



			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.DeletedAt)
				.HasColumnType("datetime");
		}
	}
}
