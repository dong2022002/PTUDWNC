using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TatBlog.Data.Contexts
{
    public class BlogDbContext :DbContext
    {
     

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

                  //modelBuilder.ApplyConfigurationsFromAssembly(
            //    typeof(CategoryMap).Assembly);
        }
    }
}
