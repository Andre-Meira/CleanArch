using AutoMapper;
using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
	public class ProcutServices : IProductServices
	{
		private IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProcutServices(IProductRepository productRepository, IMapper mapper) 
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<ProductDTO> GetByIdAsync(int? id)
		{
			var categoryEntity = await _productRepository.GetByIdAsync(id);
			return _mapper.Map<ProductDTO>(categoryEntity);
		}

		public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
		{
			var categoreisEntity = await _productRepository.GetCategoriesAsync();
			return _mapper.Map<IEnumerable<ProductDTO>>(categoreisEntity);
		}

		public async Task<ProductDTO> GetProductCategoryAsync(int? id)
		{
			var categoryEntity = await _productRepository.getProductCategoryAsync(id);
			return _mapper.Map<ProductDTO>(categoryEntity);
		}

		public async Task AddAsync(ProductDTO product)
		{
			var categoryEntity = _mapper.Map<Product>(product);
			await _productRepository.CreateAsync(categoryEntity);
		}


		public async Task UpdateAsync(ProductDTO product)
		{
			var categoryEntity = _mapper.Map<Product>(product);
			await _productRepository.UpdateAsync(categoryEntity);
		}

		public async Task RemoveAsync(int? id)
		{
			var categoryEntity = _productRepository.GetByIdAsync(id).Result;
			await _productRepository.RemoveAsync(categoryEntity);
		}
	}
}
