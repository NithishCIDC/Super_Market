using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Repository;
using SuperMarket.Domain.Models;
using System.Diagnostics;

namespace SuperMarket.Web.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductsRepository productsRepository;

		public ProductController(IProductsRepository productsRepository)
        {
			this.productsRepository = productsRepository;
		}

        [HttpGet]
		public IActionResult Index()
		{
			var ProductList = productsRepository.GetAll();
			return View(ProductList);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(ProductModel ViewModel)
		{
			if (ModelState.IsValid)
			{
				Boolean b = productsRepository.Create(ViewModel);
				if(b)
				return RedirectToAction("Index", "Product");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			var item=productsRepository.Get(id);
			return View(item);
		}

		[HttpPost]
		public IActionResult Edit(ProductModel ViewModel)
		{
			productsRepository.Update(ViewModel);
			return RedirectToAction("Index","Product");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			productsRepository.Delete(id);
			return RedirectToAction("Index", "Product");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
