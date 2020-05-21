using Dapper;
using SuggestedOrdering.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SuggestedOrdering
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
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id)
        {
            return (Product)_conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id", new { id = id });
        }
    }
}
