using CleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
	public interface ICategoryServices
	{
		Task<IEnumerable<CategoryDTO>> GetCategories();
		Task<CategoryDTO> GetById(int? id);
		Task Add(CategoryDTO categoryDTO);
		Task Update(CategoryDTO categoryDTO);
		Task Remove(int? id);
	}
}
