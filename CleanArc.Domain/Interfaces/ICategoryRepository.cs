using CleanArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Domain.Interfaces
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetCategoriesAsync();
		Task<Category> GetByIdAsync(int? id);
		Task<Category> CreateAsync(Category category);
		Task<Category> DeleteAsync(Category category);
		Task<Category> UpdateAsync(Category category);



	}

}
