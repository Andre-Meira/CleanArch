using AutoMapper;
using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
	public class CategoryService : ICategoryServices
	{
		private  ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) 
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;		
		}

		public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
		{
			var categoreisEntity =await  _categoryRepository.GetCategoriesAsync();
			return _mapper.Map<IEnumerable<CategoryDTO>>(categoreisEntity);
		}

		public async Task<CategoryDTO> GetByIdAsync(int? id)
		{
			var categoryEntity = await _categoryRepository.GetByIdAsync(id);
			return _mapper.Map<CategoryDTO>(categoryEntity);

		}

		public async Task AddAsync(CategoryDTO categoryDTO)
		{
			var categoryEntity = _mapper.Map<Category>(categoryDTO);
			await _categoryRepository.CreateAsync(categoryEntity);
		}

		public async Task UpdateAsync(CategoryDTO categoryDTO)
		{
			var categoryEntity = _mapper.Map<Category>(categoryDTO);
			await _categoryRepository.UpdateAsync(categoryEntity);
		}

		public async Task RemoveAsync(int? id)
		{
			var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
			await _categoryRepository.RemoveAsync(categoryEntity);
		}
	}
}
