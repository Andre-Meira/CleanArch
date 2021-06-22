using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.WebUI.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductServices _productServices;

		public ProductsController(IProductServices productService) 
		{
			_productServices = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var products = await  _productServices.GetProductsAsync();
			return View(products);
		}


	}
}
