using ASPCoreFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ASPCoreFirstApp.Services
{
    public class ProductsDAO : IProductsDataService
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<ProductModel> AllProducts()
        {
            // assume nothing is found
            List<ProductModel> foundProducts = new List<ProductModel>();

            // uses prepared statements for security. @username @password are defined below
            string sqlStatement = "SELECT * from dbo.Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader [3]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundProducts;
        }

        public bool Delete(ProductModel product)
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
            //assume nothing is found
            List<ProductModel> foundProducts = new List<ProductModel>();

            // uses prepared statements for security. @username @password are defined below
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // define the values of the two placeholders in the sqlStatement string
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return (foundProducts);
        }

        public int Update(ProductModel product)
        {
            throw new System.NotImplementedException();
        }
    }
}
