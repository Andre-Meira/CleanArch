using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CleanArch.WebUI.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductServices _productServices;
		private readonly ICategoryServices _CategoryServices;

		public ProductsController(IProductServices productService, ICategoryServices categoryServices ) 
		{
			_productServices = productService;
			_CategoryServices = categoryServices;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var products = await  _productServices.GetProductsAsync();
			return View(products);
		}

		[HttpGet()]
		public async Task<IActionResult> Create() 
		{
			ViewBag.CategoryId = 
				new SelectList(await _CategoryServices.GetCategoriesAsync(), "Id", "name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductDTO productDTO) 
		{
			if (ModelState.IsValid)
			{
				await _productServices.AddAsync(productDTO);
				return RedirectToAction(nameof(Index));
			}
			return View(productDTO);
		}




	}
}
