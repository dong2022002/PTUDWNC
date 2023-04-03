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
	public class AdminTypeMap : IEntityTypeConfiguration<AdminType>
	{
		public void Configure(EntityTypeBuilder<AdminType> builder)
		{
			builder.ToTable("AdminType");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.AdminTypeName)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(x => x.Permissisons)
				.IsRequired()
				.HasMaxLength(100);
		
			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");

		}
	}
}
