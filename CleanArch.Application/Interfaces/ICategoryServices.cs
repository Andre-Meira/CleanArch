using CleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
	public interface ICategoryServices
	{
		Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
		Task<CategoryDTO> GetByIdAsync(int? id);
		Task AddAsync(CategoryDTO categoryDTO);
		Task UpdateAsync(CategoryDTO categoryDTO);
		Task RemoveAsync(int? id);
	}
}
