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
            return (Product)_conn.QuerySingleOrDefault<Product>("SELECT * FROM products WHERE ProductID = @id", new { id = id });
        }
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET UsageNumber = @usageNumber, OnHand = @onHand WHERE ProductID = @id",
                new { usageNumber = product.UsageNumber, onHand = product.OnHand, id = product.ProductID });
        }
        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (ItemNumber, Description, CaseSize, UsageNumber, OnHand) VALUES " +
                "(@itemNumber, @description, @caseSize, @usageNumber, @onHand);", new
                {
                    itemNumber = productToInsert.ItemNumber,
                    description = productToInsert.Description,
                    caseSize = productToInsert.CaseSize,
                    usageNumber = productToInsert.UsageNumber,
                    onHand = productToInsert.OnHand
                });
        }
    }
}
