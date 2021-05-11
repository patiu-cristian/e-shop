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
            if (!this.ModelState.IsValid) 
            {
                return this.View();    
            }

            this.productRepository.Add(product);
            return this.RedirectToAction("Index");
        }

        public IActionResult PostProduct() 
        {
           return this.View();
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id, ProductModel product) 
        {
            if (product.Id != id)
            {
                return this.View();   
            }

            this.productRepository.Remove(id);
            return this.RedirectToAction("Index");      
        }

        public IActionResult DeleteProduct(int id)
        {
            return this.View(this.productRepository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(int id ,ProductModel product)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (product.Id != id)
            {
                return this.View();
            }

            this.productRepository.Update(product, id);
            return this.RedirectToAction("Index");
        }

        public IActionResult EditProduct(int id) 
        {
            return this.View(this.productRepository.GetById(id));
        }
    }
}
