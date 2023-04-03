using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Mapings
{
	public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
	{
	
		public void Configure(EntityTypeBuilder<ProductCategory> builder)
		{
			builder.ToTable("ProductCategory");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Description)
				.IsRequired()
				.HasMaxLength(100);


			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.DeletedAt)
				.HasColumnType("datetime");


		}
	}
}
