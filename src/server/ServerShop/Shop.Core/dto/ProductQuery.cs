using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.DTO
{
	public class ProductQuery
	{
		public string Keyword { get; set; }
		public string TitleSlug { get; set; }
		public string CategorySlug { get; set; }
		public int? CategoryId { get; set; }
	}
}
