using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using SuperMarket.Application.Contracts.Presistence;
using SuperMarket.Domain.Models;
using System.Diagnostics;

namespace SuperMarket.Web.Controllers
{
    public class ProductController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public ProductController(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
		}

        [HttpGet]
		public async Task<IActionResult> Index()
		{
			var ProductList = await unitOfWork.ProductsRepository.GetAll();
			return View(ProductList);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductModel ViewModel)
		{
			if (ModelState.IsValid)
			{
				unitOfWork.ProductsRepository.Create(ViewModel);
				await unitOfWork.SaveAsync();
				return RedirectToAction("Index", "Product");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			var item = unitOfWork.ProductsRepository.Get(id);
			return View(item);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ProductModel ViewModel)
		{
			unitOfWork.ProductsRepository.Update(ViewModel);
			await unitOfWork.SaveAsync();
			return RedirectToAction("Index","Product");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			unitOfWork.ProductsRepository.Delete(id);
			await unitOfWork.SaveAsync();
			return RedirectToAction("Index", "Product");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
