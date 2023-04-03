using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
	public class AdminType
	{
        public int Id { get; set; }
        public string AdminTypeName { get; set; }
        public string Permissisons { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
	}
}
