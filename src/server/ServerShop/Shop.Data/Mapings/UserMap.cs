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
	public class UserMap : IEntityTypeConfiguration<User>
	{
		
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");

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
			builder.Property(x => x.Address)
				.HasMaxLength(100);
			builder.Property(x => x.PhoneNumber)
				.HasMaxLength(10);
			builder.Property(x => x.CreatedAt)
				.HasColumnType("datetime");
			builder.Property(x => x.ModifiedAt)
				.HasColumnType("datetime");
			
		}
	}
}
