using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using ZstdSharp.Unsafe;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Initialize DB
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            #endregion

            #region Department Section

            //var departmentRepo = new DapperDepartmentRepository(conn);

            #region InsertDepartments

            //departmentRepo.InsertDepartments("Car Audio");

            #endregion

            #region GetAllDepartments

            //var departments = departmentRepo.GetAllDepartments();

            //foreach (var department in departments)
            //{
            //    Console.WriteLine(department.DepartmentID);
            //    Console.WriteLine(department.Name);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            #endregion

            #endregion

            #region Products Section

            var productRepository = new DapperProductRepository(conn);

            #region UpdateProduct

            //var productToUpdate = productRepository.GetProduct(942);

            //productToUpdate.Name = "Updated Product";
            //productToUpdate.Price = 10;
            //productToUpdate.CategoryID = 1;
            //productToUpdate.OnSale = true;
            //productToUpdate.StockLevel = 30;

            #endregion

            #region DeleteProduct

            productRepository.DeleteProduct(942);

            #endregion

            #region GetAllProducts
            //var products = productRepository.GetAllProducts();

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductID);
            //    Console.WriteLine(product.Name);
            //    Console.WriteLine(product.Price);
            //    Console.WriteLine(product.CategoryID);
            //    Console.WriteLine(product.OnSale);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            #endregion

            #endregion
        }
    }
}
