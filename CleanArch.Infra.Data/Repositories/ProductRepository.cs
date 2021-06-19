using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		ApplicationDbContext _ProductContext;

		public ProductRepository(ApplicationDbContext productContext) 
		{
			_ProductContext = productContext;		
		}

		public async Task<Product> CreateAsync(Product product)
		{
			_ProductContext.Add(product);
			await _ProductContext.SaveChangesAsync();
			return product;
		}

		public async Task<Product> GetByIdAsync(int? id)
		{
			return await _ProductContext.products.FindAsync(id);
		}

		public async Task<IEnumerable<Product>> GetCategoriesAsync()
		{
			return await _ProductContext.products.ToListAsync();
		}

		public async Task<Product> getProductCategoryAsync(int? id)
		{
			return await _ProductContext.products.Include(c => c.Category)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<Product> RemoveAsync(Product product)
		{
			_ProductContext.Remove(product);
			await _ProductContext.SaveChangesAsync();
			return product;
		}

		public async Task<Product> UpdateAsync(Product product)
		{
			_ProductContext.Update(product);
			await _ProductContext.SaveChangesAsync();
			return product;
		}
	}
}
