using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Shops
{
	public interface IUserRepository
	{
		Task<User> checkUser(string userName, string password, CancellationToken cancellationToken = default);

		Task<bool> AddOrUpdateUser(User user, CancellationToken cancellationToken = default);
		Task<bool> AddOrderDetail(OrderDetail newOderDetail, CancellationToken cancellationToken = default);
		Task<bool> AddOrderItem(OrderItem newOrderItem, CancellationToken cancellationToken = default);

	}
}
