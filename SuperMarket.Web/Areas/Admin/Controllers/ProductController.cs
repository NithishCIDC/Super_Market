using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Contracts.Presistence;
using SuperMarket.Domain.Models;
using System.Diagnostics;

namespace SuperMarket.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
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
                await unitOfWork.ProductsRepository.Create(ViewModel);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item =await unitOfWork.ProductsRepository.Get(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel ViewModel)
        {
            await unitOfWork.ProductsRepository.Update(ViewModel);
            await unitOfWork.SaveAsync();
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await unitOfWork.ProductsRepository.Delete(id);
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
