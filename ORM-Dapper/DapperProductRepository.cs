using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(string name, double price, int categoryID, bool onSale, int stockLevel)
        {
            _conn.Execute("INSERT INTO products (Name) VALUES (@name)", new { name });
            _conn.Execute("INSERT INTO products (Price) VALUES (@price)", new { price });
            _conn.Execute("INSERT INTO products (CategoryID) VALUES (@categoryID)", new { categoryID });
            _conn.Execute("INSERT INTO products (OnSale) VALUES (@onSale)", new { onSale,});
            _conn.Execute("INSERT INTO products (StockLevel) VALUES (@stockLevel)", new { stockLevel, });

        }

        public void DeleteProduct(int id)
        {
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id", new { id });
            _conn.Execute("DELETE FROM Reviews WHERE ProductID = @id", new { id });
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id", new { id });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM Products WHERE ProductID = @id",
                new { id });

        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE Products " +
                "SET " +
                " Name = @name," +
                " Price = @price," +
                " CategoryID = @categoryID," +
                " OnSale = @onSale," +
                " StockLevel = @stock," +
                " WHERE ProductID = @id;",
                new 
                {
                    id = product.ProductID,
                    name = product.Name,
                    price = product.Price,
                    categoryID = product.CategoryID,
                    onSale = product.OnSale,
                    stock = product.StockLevel
                });
        }
    }
}
