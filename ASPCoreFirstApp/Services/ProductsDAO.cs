using ASPCoreFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ASPCoreFirstApp.Services
{
    public class ProductsDAO : IProductsDataService
    {

        /*string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
         * */
        string connectionString = "Server=tcp:activity8.database.windows.net,1433;Initial Catalog=TestDB;Persist Security Info=False;User ID=cmarkel;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundProducts;
        }

        public int Delete(ProductModel productModel)
        {
            // Returns -1 if the update fails
            int newIdNumber = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM dbo.Products WHERE Id = @Id";

                SqlCommand myCommand = new SqlCommand(query, connection);

                myCommand.Parameters.AddWithValue("@Id", productModel.Id);


                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(myCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
                return newIdNumber;
            }
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;

            // uses prepared statements for security. @username  @password are defined below
            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // define the values of the two placeholders in the sqlStatement string
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProduct = new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundProduct;
        }

        public int Insert(ProductModel productModel)
        {
            int newIdNumber = -1;

            string sqlStatement = "INSERT INTO dbo.Products (Name, Price, Description) VALUES (@Name, @Price, @Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Name", productModel.Name);
                command.Parameters.AddWithValue("@Price", productModel.Price);
                command.Parameters.AddWithValue("@Description", productModel.Description);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return newIdNumber;
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
            return foundProducts;
        }

        public int Update(ProductModel productModel)
        {
            // Returns -1 if the update fails
            int newIdNumber = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE dbo.Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";

                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("@Id", productModel.Id);
                myCommand.Parameters.AddWithValue("@Name", productModel.Name);
                myCommand.Parameters.AddWithValue("@Price", productModel.Price);
                myCommand.Parameters.AddWithValue("@Description", productModel.Description);

                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(myCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
                return newIdNumber;
            }
        }
    }
}
