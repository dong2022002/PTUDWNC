using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Shops
{
	public class UserRepository : IUserRepository
	{
		private readonly ShopDbContext _context;

		public UserRepository(ShopDbContext context)
		{
			_context = context;
		}

		public async Task<bool> AddOrderDetail(OrderDetail newOderDetail, CancellationToken cancellationToken = default)
		{
			_context.OrderDetail.Add(newOderDetail);
			return await _context.SaveChangesAsync(cancellationToken) > 0;
		}

		public async Task<bool> AddOrderItem(OrderItem newOrderItem, CancellationToken cancellationToken = default)
		{
			_context.OrderItems.Add(newOrderItem);
			return await _context.SaveChangesAsync(cancellationToken) > 0;
		}	

		public async Task<bool> AddOrUpdateUser(User user, CancellationToken cancellationToken = default)
		{
			if (user.Id <= 0)
			{
				_context.Users.Add(user);


			}
			else
			{
				_context.Set<User>().Update(user);

			}
			return (await _context.SaveChangesAsync(cancellationToken)) > 0;
		}


		public async Task<User> checkUser(string userName, string password, CancellationToken cancellationToken = default)
		{
			var user = await _context.Set<User>()
				.Where(a => a.UserName == userName)
				.FirstOrDefaultAsync(x => x.UserName == userName, cancellationToken);
			if (user == null)
			{
				return null;
			}
			else
			{
				if (user.Password == password)
				{
					return user;
				}

			}
			return null;
		}
	}
}
