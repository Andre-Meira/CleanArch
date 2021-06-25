using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Application.Products.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers 
{
	class GetProductByIdQuerryHandler : IRequestHandler<GetProductByIdQuerry, Product>
	{
		private readonly IProductRepository _productRepository;
		public GetProductByIdQuerryHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task<Product> Handle(GetProductByIdQuerry request, CancellationToken cancellationToken)
		{
			return await _productRepository.GetByIdAsync(request.Id);
		}
	}
}
