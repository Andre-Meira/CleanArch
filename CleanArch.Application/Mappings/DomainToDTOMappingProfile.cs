using AutoMapper;
using CleanArc.Domain.Entities;
using CleanArch.Application.DTOs;

namespace CleanArch.Application.Mappings
{
	public class DomainToDTOMappingProfile : Profile
	{
		public DomainToDTOMappingProfile() 
		{
			CreateMap<Product, ProductDTO>().ReverseMap();
			CreateMap<Category, CategoryDTO>().ReverseMap();
		}
	}
}
