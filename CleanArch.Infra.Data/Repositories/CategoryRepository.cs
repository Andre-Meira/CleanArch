using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{

		ApplicationDbContext _CategoryContext;

		public CategoryRepository(ApplicationDbContext context) 
		{
			_CategoryContext = context;
		}

		public async Task<Category> CreateAsync(Category category)
		{
			_CategoryContext.Add(category);
			await _CategoryContext.SaveChangesAsync();
			return category;
		}

		public async Task<Category> RemoveAsync(Category category)
		{
			_CategoryContext.Remove(category);
			await _CategoryContext.SaveChangesAsync();
			return category;
		}

		public async Task<Category> GetByIdAsync(int? id)
		{
			return await _CategoryContext.categories.FindAsync(id);
		}

		public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			return await _CategoryContext.categories.ToListAsync();
		}

		public async Task<Category> UpdateAsync(Category category)
		{
			_CategoryContext.Update(category);
			await _CategoryContext.SaveChangesAsync();
			return category;
		}
	}
}
