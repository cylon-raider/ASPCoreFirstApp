using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASPCoreFirstApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDAO repository = new ProductsDAO();

        public ProductsController()
        {
            repository = new ProductsDAO();
        }
        
        public IActionResult Index()
        {
            return View(repository.AllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            return View("Index", productList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            ViewBag.Name = "Chris";
            ViewBag.secretNumber = 13;
            return View();
        }
    }
}
 