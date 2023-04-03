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
	public class ShoppingSessionMap : IEntityTypeConfiguration<ShoppingSession>
	{
		public void Configure(EntityTypeBuilder<ShoppingSession> builder)
		{
			builder.ToTable("ShoppingSession");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.total)
				.HasDefaultValue(0);
			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");

			builder.HasOne(x => x.User)
				.WithMany(x => x.ShoppingSessions)
				.HasForeignKey(x => x.UserId)
				.HasConstraintName("FK_User_ShoppingSessions")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
