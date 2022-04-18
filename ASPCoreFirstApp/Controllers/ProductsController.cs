using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASPCoreFirstApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDAO repository;
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

        public IActionResult ShowOneProduct(int Id)
        {
            return View(repository.GetProductById(Id));
        }

        public IActionResult ShowOneProductJSON(int Id)
        {
            return Json(repository.GetProductById(Id));
        }

        public IActionResult ShowEditForm(int Id)
        {
            return View(repository.GetProductById(Id));
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return View("Index", repository.AllProducts());
        }

        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            repository.Update(product);
            return PartialView("_productCard", product);
        }

        public IActionResult Delete(int Id)
        {
            ProductModel product = repository.GetProductById(Id);
            repository.Delete(product);
            return View("Index", repository.AllProducts());
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
