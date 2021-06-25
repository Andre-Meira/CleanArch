using CleanArc.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Application.Mappings;
using System;
using MediatR;

namespace CleanArch.Infra.Ioc
{
	public static class DepedencyInjetction
	{
		public static IServiceCollection addInfrastructure(this IServiceCollection services,
			IConfiguration configuration) 		
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
			), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryServices, CategoryService>();
			services.AddScoped<IProductServices, ProcutServices>();
			services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
			
			var myhandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
			services.AddMediatR(myhandlers);

			return services; 
		}

	}
}
