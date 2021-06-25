using CleanArc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Queries
{
	public class GetProductByIdQuerry : IRequest<Product>
	{
		public int Id { get; set;}

		public GetProductByIdQuerry(int id)
		{
			Id = id;
		}


	}
}
