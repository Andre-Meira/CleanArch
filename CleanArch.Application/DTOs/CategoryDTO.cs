using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs
{
	public class CategoryDTO
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="The name is Required")]
		[MaxLength(100)]
		[MinLength(3)]
		public string name { get; set; }

	}
}
