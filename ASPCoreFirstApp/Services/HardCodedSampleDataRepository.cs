using ASPCoreFirstApp.Models;
using Bogus;
using System.Collections.Generic;

namespace ASPCoreFirstApp.Services
{
    public class HardCodedSampleDataRepository : IProductsDataService
    {

        // use static to ensure the data set does not change
        static List<ProductModel> productList = new List<ProductModel>();

        // create the list in the constructor of the service
        public HardCodedSampleDataRepository()
        {
            if (productList.Count == 0)
            {
                productList = new List<ProductModel>();

                productList.Add(new ProductModel(1, "Mouse Pad", 5.99m, "A square piece of plastic" +
                    "to make mousing easier"));
                productList.Add(new ProductModel(2, "Web Cam", 45.50m, "Enables you to attend more" +
                    "zoom meetings"));
                productList.Add(new ProductModel(3, "4 TB USB Hard Drive", 130.00m, "Back up all your work. You won't regret it"));
                productList.Add(new ProductModel(4, "Wireless Mouse", 15.99m, "Notebook mice really don't work very well. Do they?"));

                for (int i = 0; i < 100; i++)
                {
                    productList.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 5)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }
            }
        }

        public List<ProductModel> AllProducts()
        {
            return productList;
        }

        public int Delete(ProductModel product)
        {
            throw new System.NotImplementedException();
        }

        public ProductModel GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new System.NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new System.NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new System.NotImplementedException();
        }
    }
}
