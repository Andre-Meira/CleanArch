using CleanArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Domain.Interfaces
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetCategoriesAsync();
		Task<Product> GetByIdAsync(int? id);
		Task<Product> getProductCategoryAsync(int? id);
		Task<Product> CreateAsync(Product product);
		Task<Product> RemoveAsync(Product product);
		Task<Product> UpdateAsync(Product product);           
	}
}
