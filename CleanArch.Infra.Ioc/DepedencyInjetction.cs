﻿using CleanArc.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			return services; 
		}

	}
}
