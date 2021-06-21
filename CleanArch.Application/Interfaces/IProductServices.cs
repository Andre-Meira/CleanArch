using CleanArch.Application.DTOs;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
	interface IProductServices 
	{
		public Task<ProductDTO> GetById(int? id);
		public Task<IEnumerable<ProductDTO>> GetProducts();
		public Task<ProductDTO> GetProductCategory(int? id);
		public Task Add(ProductDTO product);
		public Task Remove(int? id);
		public Task Update(ProductDTO product);

	}
}
