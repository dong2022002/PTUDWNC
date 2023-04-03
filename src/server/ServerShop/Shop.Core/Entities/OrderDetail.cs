using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
	public class OrderDetail
	{
        public int Id { get; set; }
        public double Total { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }

        public PaymentDetail PaymentDetail { get; set; }
        public User User { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}
