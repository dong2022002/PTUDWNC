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
	public class AdminUserRepository : IAdminUserRepository
	{

		private readonly ShopDbContext _context;

		public AdminUserRepository(ShopDbContext context)
		{
			_context = context;
		}

		public async Task<AdminUser> checkAdmin(string userName, string password, CancellationToken cancellationToken =default)
		{
			var admin = await _context.Set<AdminUser>()
				.Where(a => a.UserName == userName)
				.FirstOrDefaultAsync(x => x.UserName == userName, cancellationToken);
			if (admin == null )
			{
				return null;
			}
			else
			{
                if (admin.Password == password)
                {
					return admin;
                }
			
            }
			return null;

			
		}
	}
}
