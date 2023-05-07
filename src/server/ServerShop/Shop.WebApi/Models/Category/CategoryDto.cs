using System;

namespace Shop.WebApi.Models.Category
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }

		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
