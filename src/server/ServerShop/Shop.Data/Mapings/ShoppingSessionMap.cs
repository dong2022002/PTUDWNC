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
		//public int Id { get; set; }
		//public double total { get; set; }
		//public int MyProperty { get; set; }

		//public int UserId { get; set; }
		//public User User { get; set; }

		//public IList<CartItem> Carts { get; set; }
		public void Configure(EntityTypeBuilder<ShoppingSession> builder)
		{
			builder.ToTable("ShoppingSession");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.total)
				.HasDefaultValue(0);


			builder.HasOne(x => x.User)
				.WithMany(x => x.ShoppingSessions)
				.HasForeignKey(x => x.UserId)
				.HasConstraintName("FK_User_ShoppingSessions")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
