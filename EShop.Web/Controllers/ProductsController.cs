using EShop.Web.Models;
using EShop.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController(IRepository<ProductModel> product)
        {
            this.ProductRepository = product;
        }
        public IRepository<ProductModel> ProductRepository;
        
        public IActionResult Index()
        {
            var produse = ProductRepository.GetAll();
            return View(produse);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductModel product)
        {
            if (ModelState.IsValid) 
            { 
                ProductRepository.Add(product);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult AddProduct() 
        {
           return View();
        }
    }
}
