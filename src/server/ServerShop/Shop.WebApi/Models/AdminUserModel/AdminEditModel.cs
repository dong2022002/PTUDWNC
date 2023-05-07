using Microsoft.AspNetCore.Http;
using Shop.WebApi.Models.Category;
using System.Threading.Tasks;

namespace Shop.WebApi.Models.AdminUserModel
{
	public class AdminEditModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public static async ValueTask<AdminEditModel> BindAsync(
				HttpContext context)
		{
			var form = await context.Request.ReadFormAsync();
			return new AdminEditModel()
			{
				UserName = form["UserName"],
				Password = form["Password"],
			};
		}
	}
}
