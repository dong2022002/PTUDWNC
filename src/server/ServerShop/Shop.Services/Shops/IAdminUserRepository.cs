using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Shops
{
	public interface IAdminUserRepository
	{
		Task<AdminUser> checkAdmin(string userName, string password, CancellationToken cancellationToken =default);
	}
}
