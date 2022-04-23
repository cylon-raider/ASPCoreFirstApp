using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASPCoreFirstApp.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductsAPIController : ControllerBase
    {
        ProductsDAO repository;
        public ProductsAPIController()
        {
            repository = new ProductsDAO();
        }
        // no route specified since this is the default
        // /api/productsapi
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> Index()
        {
            // fetch all products from the database in productModel format.
            List<ProductModel> productList = repository.AllProducts();
            // translate the list into a list of productDTO objects
            IEnumerable<ProductDTO> productDTOList = from p in productList
                                                     select
                                                     new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOList;
        }

        // GET /api/productsapi/searchproducts/xyz
        [HttpGet("searchproducts/{searchTerm}")]
        public IEnumerable<ProductDTO> SearchProducts(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);

            // translate into DTO
            IEnumerable<ProductDTO> productDTOList = from p in productList
                                                     select
                                                     new ProductDTO(p.Id, p.Name, p.Price, p.Description);

            return productDTOList;
        }


        // GET /api/productsapi/showoneproduct/3
        [HttpGet("showoneproduct/{Id}")]
        [ProducesDefaultResponseType(typeof(ProductDTO))]
        public ActionResult<ProductDTO> ShowOneProduct(int Id)
        {
            // get the correct product from the database.
            ProductModel product = repository.GetProductById(Id);

            // create a new DTO based on the product
            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price, product.Description);

            // return the DTO instead of the product
            return productDTO;
        }

        // post action
        // expecting a product in json format in the body of the request
        [HttpPost("insertone")]
        public ActionResult<int> InsertOne(ProductModel product)
        {
            int newId = repository.Insert(product);
            return newId;
        }

        // put request
        // expect a json format
        [HttpPut("processedit")]
        [ProducesDefaultResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            List<ProductModel> productList = repository.AllProducts();

            // translate into DTO
            IEnumerable<ProductDTO> productDTOList = from p in productList
                                                     select new ProductDTO(p.Id, p.Name, p.Price, p.Description);

            return productDTOList;
        }

        // GET /api/productsapi/processeditreturnoneitem/product
        [HttpPut("ProcessEditReturnOneItem")]
        [ProducesDefaultResponseType(typeof(ProductDTO))]
        public ActionResult<ProductDTO> ProcessEditReturnOneItem(ProductModel product)
        {
            repository.Update(product);
            ProductModel updatedProduct = repository.GetProductById(product.Id);
            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price, product.Description);

            return productDTO;
        }

        /*

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
               }*/
    }
}
