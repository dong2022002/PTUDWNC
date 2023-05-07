using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.dto
{
	public class DiscountItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double DiscountPercent { get; set; }
		public bool Active { get; set; }

        public int ProductCount { get; set; }
    }
}
