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
	public class UserPaymentMap : IEntityTypeConfiguration<UserPayment>
	{
		//public int Id { get; set; }
		//public string PaymentType { get; set; }
		//public string Provider { get; set; }
		//public int AccountNo { get; set; }
		//public DateTime Expiry { get; set; }
		//public int UseId { get; set; }

		//public User User { get; set; }
		public void Configure(EntityTypeBuilder<UserPayment> builder)
		{
			builder.ToTable("UserPayment");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.PaymentType)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Provider)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.AccountNo)
				.HasDefaultValue(null);

			builder.Property(x => x.Expiry)
				.HasColumnType("datetime");

			builder.HasOne(x => x.User)
				.WithMany(x => x.UserPayments)
				.HasForeignKey(x => x.UseId)
				.HasConstraintName("FK_User_UserPayments")
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
