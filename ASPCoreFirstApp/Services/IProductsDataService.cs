using ASPCoreFirstApp.Models;
using System.Collections.Generic;

namespace ASPCoreFirstApp.Services
{
    public interface IProductsDataService
    {
        List<ProductModel> AllProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int id);
        int Insert(ProductModel productModel);
        int Delete(ProductModel productModel);
        int Update(ProductModel productModel);
    }
}
