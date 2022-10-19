﻿using ASPNETCoreMVC.Models;
using Dapper;
using System.Data;


namespace ASPNETCoreMVC
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM Products;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM Products WHERE ProductID = @id ;", new {id = id});
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name=@Name, Price=@Price WHERE ProductID = @id;",
                new {name=product.Name, price = product.Price, id = product.ProductID});
        }

        
    }
}
