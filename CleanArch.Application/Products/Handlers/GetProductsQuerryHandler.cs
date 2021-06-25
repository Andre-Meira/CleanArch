using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers 
{
	class GetProductsQuerryHandler : IRequestHandler<GetProductsQuerry, IEnumerable<Product>>
	{
		private readonly IProductRepository _productRepository;
		public GetProductsQuerryHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task<IEnumerable<Product>> Handle(GetProductsQuerry request, CancellationToken cancellationToken)
		{
			return await _productRepository.GetProductAsync();
		}
	}
}
