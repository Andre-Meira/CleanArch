using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.WebUI.Controllers
{
	public class CategoriesController : Controller
	{
		private ICategoryServices _categoryServices;

		public CategoriesController(ICategoryServices categoryServices)
		{
			_categoryServices = categoryServices;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var categoreis = await _categoryServices.GetCategoriesAsync();
			return View(categoreis);
		}

		[HttpGet]
		public IActionResult Create() 
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CategoryDTO categoryDTO) 
		{
			if (ModelState.IsValid) 
			{
				await _categoryServices.AddAsync(categoryDTO);
				return RedirectToAction(nameof(Index));
			}
			return View();
		}
	}
}
