using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Contracts.Presistence;

namespace SuperMarket.Web.Areas.Admin.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CustomerProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ProductList = await unitOfWork.ProductsRepository.GetAll();
            return View(ProductList);
        }

    }
}
