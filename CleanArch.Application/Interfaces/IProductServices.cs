using CleanArch.Application.DTOs;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
	public interface IProductServices 
	{
		public Task<ProductDTO> GetByIdAsync(int? id);
		public Task<IEnumerable<ProductDTO>> GetProductsAsync();
		public Task<ProductDTO> GetProductCategoryAsync(int? id);
		public Task AddAsync(ProductDTO product);
		public Task RemoveAsync(int? id);
		public Task UpdateAsync(ProductDTO product);

	}
}
