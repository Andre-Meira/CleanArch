using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Mappings
{
	public class DTOToComanndMappingProfile : Profile
	{
		public DTOToComanndMappingProfile()
		{
			CreateMap<ProductDTO, ProductCreateCommand>();
			CreateMap<ProductDTO, ProductUpdateCommand>();
		}
	}
}
