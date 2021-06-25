using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Application.Products.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers
{
	class ProcutUpdateCommandsHandler : IRequestHandler<ProductUpdateCommand, Product>
	{
		private readonly IProductRepository _productRepository;
		public ProcutUpdateCommandsHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetByIdAsync(request.Id);

			if (product == null) 
			{
				throw new ApplicationException("Entity Could not Be fooud");
			}
			{
				product.Update(request.Name, request.Description, request.Price,
					request.Stock, request.Image, request.CategoryId);
				return await _productRepository.UpdateAsync(product);
			}
		
		}
	}
}
