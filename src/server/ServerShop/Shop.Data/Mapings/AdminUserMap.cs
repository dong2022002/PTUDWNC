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
	public class AdminUserMap : IEntityTypeConfiguration<AdminUser>
	{
		public void Configure(EntityTypeBuilder<AdminUser> builder)
		{
			builder.ToTable("AdminUser");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.UserName)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(x => x.Password)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(x => x.FirstName)
				.IsRequired()
				.HasMaxLength(30);
			builder.Property(x => x.LastName)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(x => x.LastLogin)
				.HasColumnType("datetime");
			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");

			builder.HasOne(x => x.AdminType)
				.WithMany(x => x.AdminUsers)
				.HasForeignKey(x => x.TypeId)
				.HasConstraintName("FK_AdminType_AdminUsers")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
