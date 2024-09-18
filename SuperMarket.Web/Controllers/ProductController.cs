using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.Repository;
using SuperMarket.Domain.Models;
using SuperMarket.Infrastructure.Data;
using System.Diagnostics;

namespace SuperMarket.Web.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext dbContext;
		private readonly IProductsRepository productsRepository;

		public ProductController(ApplicationDbContext dbContext,IProductsRepository productsRepository)
        {
			this.dbContext = dbContext;
			this.productsRepository = productsRepository;
		}

        [HttpGet]
		public async Task<IActionResult> Index()
		{
			//List<ProductModel> ProductList = await dbContext.Products.ToListAsync();
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
			//if(ViewModel.Discount is null)
			//{
			//	ViewModel.Discount = 0;
			//}
			if (ModelState.IsValid)
			{
				
				//dbContext.Products.AddAsync(ViewModel);
				//dbContext.SaveChanges();

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
			//var item = await dbContext.Products.FindAsync(id);
			return View(item);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ProductModel ViewModel)
		{
			//var item = await dbContext.Products.FindAsync(ViewModel.id);
			//if(item is not null)
			//{
			//	item.Name = ViewModel.Name;
			//	item.Quantity = ViewModel.Quantity;
			//	item.Price = ViewModel.Price;
			//	if(ViewModel.Discount is not null)
			//	item.Discount = ViewModel.Discount;
			//	else
			//	item.Discount = 0;
			//}
			//dbContext.SaveChanges();
			return RedirectToAction("Index","Product");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var item = await dbContext.Products.FindAsync(id);
			if(item is not null)
			{
				dbContext.Products.Remove(item);
				dbContext.SaveChanges();
			}
			return RedirectToAction("Index", "Product");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
