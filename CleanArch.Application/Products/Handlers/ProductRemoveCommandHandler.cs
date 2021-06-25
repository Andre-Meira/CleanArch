using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Application.Products.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers
{
	class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
	{
		private readonly IProductRepository _productRepository;
		public ProductRemoveCommandHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
		{
			Product product = await _productRepository.GetByIdAsync(request.Id);

			if (product == null) 
			{
				throw new ApplicationException("Entity Could not Be fooud");
			}
			{
				Product result = await _productRepository.RemoveAsync(product);
				return result;
			}
		}
	}
}
