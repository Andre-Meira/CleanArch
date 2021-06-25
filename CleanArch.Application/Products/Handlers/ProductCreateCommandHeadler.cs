using CleanArc.Domain.Entities;
using CleanArc.Domain.Interfaces;
using CleanArch.Application.Products.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers
{
	public class ProductCreateCommandHeadler : IRequestHandler<ProductCreateCommand, Product>
	{
		private readonly IProductRepository _productRepository;
		public ProductCreateCommandHeadler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
		{
			Product product = new Product(request.Name, request.Description, request.Price, request.Stock , request.Image);
			if (product == null)
			{
				throw new ApplicationException("Error Creating Entity");
			}
			else 
			{
				product.CategoryId = request.CategoryId;
				return await _productRepository.CreateAsync(product);
			}
		}
	}
}
