using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
	public class ProcutServices : IProductServices
	{		
		private readonly IMapper _mapper;
		private readonly IMediator _madiator;

		public ProcutServices(IMapper mapper, IMediator madiator) 
		{			
			_mapper = mapper;
			_madiator = madiator; 
		}

		public async Task<ProductDTO> GetByIdAsync(int? id)
		{
			var productQuerry = new GetProductByIdQuerry(id.Value);
			if (productQuerry == null)
				throw new Exception("Entity could not be loaded");

			var result = await _madiator.Send(productQuerry);
			return _mapper.Map<ProductDTO>(result);
		}

		public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
		{
			var productQuerry = new GetProductsQuerry();
			if (productQuerry == null)
				throw new Exception("Entity could not be loaded");

			var result = await _madiator.Send(productQuerry);

			return _mapper.Map<IEnumerable<ProductDTO>>(result);		
		}

		public async Task<ProductDTO> GetProductCategoryAsync(int? id)
		{
			var productQuerry = new GetProductByIdQuerry(id.Value);
			if (productQuerry == null)
				throw new Exception("Entity could not be loaded");

			var result = await _madiator.Send(productQuerry);
			return _mapper.Map<ProductDTO>(result); 
		}

		public async Task AddAsync(ProductDTO product)
		{
			var productCreateCommand = _mapper.Map<ProductCreateCommand>(product);
			await _madiator.Send(productCreateCommand);
		}


		public async Task UpdateAsync(ProductDTO product)
		{
			var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);
			await _madiator.Send(productUpdateCommand);
		}

		public async Task RemoveAsync(int? id)
		{
			var productRemoveCommand = new ProductRemoveCommand(id.Value);
			
			if (productRemoveCommand == null)
				throw new Exception("Entity could not be loaded");
			
			await _madiator.Send(productRemoveCommand);
		}
	}
}
