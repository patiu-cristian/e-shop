using EShop.Web.Models;
using EShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Web.Controllers
{
    public class ProductsController : Controller
    {     
        private readonly IRepository<ProductModel> productRepository;

        public ProductsController(IRepository<ProductModel> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return this.View(this.productRepository.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostProduct(ProductModel product)
        {
            if (this.ModelState.IsValid) 
            { 
                this.productRepository.Add(product);

                return this.RedirectToAction("Index");
            }

            return this.View();
        }

        public IActionResult PostProduct() 
        {
           return this.View();
        }
    }
}
